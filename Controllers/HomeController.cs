using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeltaCargoSRL.Models;
using DeltaCargoSRL.Models.API;
using DeltaCargoSRL.Models.Interfaz;
using RestSharp;
using Newtonsoft.Json;
using static DeltaCargoSRL.Utils.UtilsApp;
using DeltaCargoSRL.Models.Types;
using DeltaCargoSRL.Models.ViewModels;

namespace DeltaCargoSRL.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepositoryApi<TruckTypeModel> repositoryTruck;
        private readonly IRepositoryApi<MacroRouteModel> repositoryRoute;

        public HomeController(IRepositoryApi<TruckTypeModel> repositoryTruck
            ,IRepositoryApi<MacroRouteModel> repositoryRoute)
        {
            this.repositoryTruck = repositoryTruck;
            this.repositoryRoute = repositoryRoute;
        }

        public IActionResult Index()
        {
            // inicializar instancia 
            initVarEnviroment(DevelopmentEnvironment.AzureServer);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*public IActionResult Chofer()
        {
            repositoryTruck.setResource("truck/");
            ViewData["truckTypes"] = repositoryTruck.getAll();

            repositoryRoute.setResource("route/");
            //ViewData["routes"] = repositoryRoute.getAll();
            CarrierModel model = new CarrierModel {
                ids_Route = repositoryRoute.getAll().ToList() 
            };

            return View(model);
        }*/

        // obtener los listados: Tipos de camion, Rutas
        /*public IActionResult Cliente()
        {
            //string urlRequest = @"http://deltacargoapi.azurewebsites.net/api/v1/";
            string urlRequest = @"https://localhost:44333/api/v1/";
            var responseProjects = new RequestAPI()
                .addClient(new RestClient(urlRequest))
                .addRequest(new RestRequest("quotation/", Method.GET))
                .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                .buildRequest();

            QuotationViewModel quotationFormat = JsonConvert.DeserializeObject<QuotationViewModel>(responseProjects);
            return View(quotationFormat);
        }*/







    }
}
