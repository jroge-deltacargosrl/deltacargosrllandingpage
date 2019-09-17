using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeltaCargoSRL.Models;
using DeltaCargoSRL.Models.API;
using DeltaCargoSRL.Models.Interfaz;
using DeltaCargoSRL.Models.Infraestructure;
using RestSharp;
using Newtonsoft.Json;

namespace DeltaCargoSRL.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepositoryCrud<TruckTypeModel> repositoryTruck;
        private readonly IRepositoryCrud<MacroRouteModel> repositoryRoute;

        public HomeController(IRepositoryCrud<TruckTypeModel> repositoryTruck
<<<<<<< HEAD
            ,IRepositoryCrud<MacroRouteModel> repositoryRoute)
=======
            , IRepositoryCrud<RouteModel> repositoryRoute)
>>>>>>> f448d3df1137a1bfb74ffe186821befad1b92dbd
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
            string urlRequest = @"http://deltacargoapi.azurewebsites.net/api/v1/";
            var responseProjects = new RequestAPI()
                .addClient(new RestClient(urlRequest))
                .addRequest(new RestRequest("quotation/", Method.GET))
                .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                .buildRequest();
            QuotationViewModel quotationFormat = JsonConvert.DeserializeObject<QuotationViewModel>(responseProjects);
            quotationFormat = new QuotationViewModel()
            {
                serviceTypes = new List<ServiceTypeModel>()
                {
                    new ServiceTypeModel()
                    {
                        id=1,
                        name ="Transporte Urbano"
                    },
                    new ServiceTypeModel()
                    {
                        id=2,
                        name ="Almacenamiento de Carga"
                    },
                    new ServiceTypeModel()
                    {
                        id=3,
                        name ="Transporte Nacional"
                    },
                    new ServiceTypeModel()
                    {
                        id=4,
                        name ="Transporte Internacional"
                    }
                },
                macroRoutes = new List<RouteModel>()
                {
                    new RouteModel()
                    {
                        id=1,
                        pais="Bolivia"
                    },
                    new RouteModel()
                    {
                        id=2,
                        pais="Argentina"
                    },
                    new RouteModel()
                    {
                        id=3,
                        pais="Peru"
                    }
                },
                trucksTypes = new List<TruckTypeModel>()
                {
                    new TruckTypeModel()
                    {
                        id=1,
                        tipo="A"
                    },
                    new TruckTypeModel()
                    {
                        id=2,
                        tipo="B"
                    },
                    new TruckTypeModel()
                    {
                        id=3,
                        tipo="C"
                    }
                }
            };
            return View(quotationFormat);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
