using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeltaCargoSRL.Models;
using DeltaCargoSRL.Models.API;
using DeltaCargoSRL.Models.Interfaz;

namespace DeltaCargoSRL.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepositoryCrud<TruckTypeModel> repositoryTruck;
        private readonly IRepositoryCrud<MacroRouteModel> repositoryRoute;

        public HomeController(IRepositoryCrud<TruckTypeModel> repositoryTruck
            ,IRepositoryCrud<MacroRouteModel> repositoryRoute)
        {
            this.repositoryTruck = repositoryTruck;
            this.repositoryRoute = repositoryRoute;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Chofer()
        {
            repositoryTruck.setResource("truck/");
            ViewData["truckTypes"] = repositoryTruck.getAll();

            repositoryRoute.setResource("route/");
            //ViewData["routes"] = repositoryRoute.getAll();
            CarrierModel model = new CarrierModel { ids_Route = repositoryRoute.getAll() };

            return View(model);
        }

        // obtener los listados: Tipos de camion, Rutas
        public IActionResult Cliente()
        {
           



            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
