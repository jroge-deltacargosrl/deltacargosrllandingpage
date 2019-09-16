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

        private readonly IRepositoryCrud<CarrierModel> repositoryCarrier;

        public CarrierController(IRepositoryCrud<CarrierModel> repositoryCarrier)
        {
            this.repositoryCarrier = repositoryCarrier;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
             return View(deserializeJSON<CarrierModel>(TempData["newCarrier"].ToString()));
        }


        /// <summary>
        /// Realiza una pre registro del transportista interesado en trabajar con delta cargo srl
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(CarrierModel carrier)
        {
            if (ModelState.IsValid)
            {
                repositoryCarrier.setResource("carrier/");
                CarrierModel newCarrier = repositoryCarrier.create(carrier);
                TempData["newCarrier"] = serializeJSON(newCarrier);
                return RedirectToAction(nameof(Details));
            }
            return View();
            //return RedirectToAction("DetalleChofer",carrier); // modificar
        }

    }
}
