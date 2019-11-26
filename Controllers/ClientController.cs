using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaCargoSRL.Models;
using DeltaCargoSRL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using DeltaCargoSRL.Models.Interfaz;
using static DeltaCargoSRL.Utils.UtilsApp;

namespace DeltaCargoSRL.Controllers
{
    public class ClientController : Controller
    {
        // Refactorizar exactamente al patron Repository con unit of work
        private readonly IRepositoryApi<QuotationModel> quotationRepository;
        private readonly IRepositoryApi<QuotationViewModel> quotationViewModelRepository;
        private readonly IRepositoryApi<ClientModel> clientRepository;

        public ClientController(IRepositoryApi<QuotationModel> repositoryQuotation, IRepositoryApi<QuotationViewModel> repositoryQuotationViewModel, IRepositoryApi<ClientModel> clientRepository)
        {
            this.quotationRepository = repositoryQuotation;
            this.quotationViewModelRepository = repositoryQuotationViewModel;
            this.clientRepository = clientRepository;
        }

        // Analizar enviar el parametro ID para extender la funcionalidad del metodo
        // a la accion editar {id?}
        public IActionResult Create()
        {
            
            quotationViewModelRepository.setResource("quotation/dataRequired");
            // reestructurar la llamada a este metodo
            TempData["quotationViewModel"] = serializeJSON(quotationViewModelRepository.get());
            return View(new QuotationModel());
            
            
            /*
              string urlRequest = @"http://deltacargoapi.azurewebsites.net/api/v1/";
              string urlRequest = @"https://localhost:44333/api/v1/";
              var responseProjects = new RequestAPI()
                .addClient(new RestClient(urlRequest))
                .addRequest(new RestRequest("quotation/", Method.GET))
                .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                .buildRequest();
            QuotationViewModel quotationFormat = JsonConvert.DeserializeObject<QuotationViewModel>(responseProjects);
            return View(quotationFormat);
            */
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QuotationModel quotation)
        {
            bool actionSuccessfully = ModelState.IsValid;
            if (actionSuccessfully)
            {
                // pre: register client
                clientRepository.setResource("client/");
                // metodo utilitario 
                var clientModel = getClientFromQuotation(quotation);
                var clientCreated = clientRepository.create(clientModel);
                // asignar el ID del nuevo objeto creado
                quotation.idContact = clientCreated.id;
                // call method api
                quotationRepository.setResource("quotation/");
                var quotationCreated = quotationRepository.create(quotation);
                
                // Mandar un mensaje de registro satisfactorio
                TempData["registerSuccessfully"] = true;
                
                quotation = new QuotationModel();
                ModelState.Clear();
                // redirect method
                //return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            TempData["quotationViewModel"] = serializeJSON(quotationViewModelRepository.get());
            
            
            return View(quotation);
        } 





    }
}