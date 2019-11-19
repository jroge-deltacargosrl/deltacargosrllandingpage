using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaCargoSRL.Models;
using DeltaCargoSRL.Models.Interfaz;
using Microsoft.AspNetCore.Mvc;
using static DeltaCargoSRL.Utils.UtilsApp;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeltaCargoSRL.Controllers
{
    public class CarrierController : Controller
    {
        // aplicar el patron de diseño "Unit Of Work"
        private readonly IRepositoryApi<CarrierModel> repositoryCarrier;
        private readonly IRepositoryApi<TruckTypeModel> repositoryTruckType;
        private readonly IRepositoryApi<MacroRouteModel> repositoryRoute;

        public CarrierController(IRepositoryApi<CarrierModel> repositoryCarrier, IRepositoryApi<TruckTypeModel> repositoryTruckType, IRepositoryApi<MacroRouteModel> repositoryRoute)
        {
            this.repositoryCarrier = repositoryCarrier;
            this.repositoryTruckType = repositoryTruckType;
            this.repositoryRoute = repositoryRoute;
        }

        public IActionResult Details()
        {
            var newCarrier = deserializeJSON<CarrierModel>(TempData["newCarrier"].ToString());

             return View(newCarrier);
        }

        [HttpGet]
        public IActionResult Create()
        {
            repositoryTruckType.setResource("truck/");
            ViewData["truckTypes"] = repositoryTruckType.getAll();

            repositoryRoute.setResource("route/");
            //ViewData["routes"] = repositoryRoute.getAll();
            // Refactorizar este modelo con un ViewModel
            CarrierModel model = new CarrierModel
            {
                ids_Route = repositoryRoute.getAll().ToList()
            };
            return View(model);
        }


        /// <summary>
        /// Realiza una pre registro del transportista interesado en trabajar con delta cargo srl
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarrierModel carrier)
        {
            bool actionSuccessfully = ModelState.IsValid;
            if (actionSuccessfully)
            {
                repositoryCarrier.setResource("carrier/");
                CarrierModel carrierCreated = repositoryCarrier.create(carrier);
                
                TempData["newCarrier"] = serializeJSON(carrierCreated);
                
                TempData["registerSuccessfully"] = true;
                carrier = new CarrierModel
                {
                    ids_Route = repositoryRoute.getAll().ToList()
                };
                ModelState.Clear();
                //return RedirectToAction(nameof(Details));
            }
            // listar los datos necesarios para las relaciones de la clase Carrier
            ViewData["truckTypes"] = repositoryTruckType.getAll();
            return View(carrier);
            //return RedirectToAction("DetalleChofer",carrier); // modificar
        }

    }
}
