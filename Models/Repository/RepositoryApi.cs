
using DeltaCargoSRL.Models.API;
using DeltaCargoSRL.Models.Interfaz;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DeltaCargoSRL.Utils.UtilsApp;

namespace DeltaCargoSRL.Models.Repository
{
    public class RepositoryApi<T> : IRepositoryApi<T>
    {

        private readonly RequestAPI requestApi;
        private string resource; // url donde se debera apuntar

        public RepositoryApi(RequestAPI requestApi)
        {
            this.requestApi = requestApi;
        }

        public T create(T value)
        {
            return deserializeJSON<T>(
                requestApi.addClient(URL_BASE)
                   .addRequest(new RestRequest(resource, Method.POST, DataFormat.Json))
                   .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                   .addBodyData(value)
                   .buildRequest()
                );
        }

        public void setResource(string resource)
        {
            this.resource = resource;
        }

        public T update(int id, T value)
        {
            throw new NotImplementedException();
        }

        T IRepositoryApi<T>.delete(int id)
        {
            throw new NotImplementedException();
        }

        T IRepositoryApi<T>.get(int id = 0)
        {
            return deserializeJSON<T>(
                requestApi.addClient(URL_BASE)
                .addRequest(new RestRequest(resource, Method.GET, DataFormat.Json))
                .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                .buildRequest()
            );
        }

        IEnumerable<T> IRepositoryApi<T>.getAll()
        {
            return deserializeJSON<IEnumerable<T>>(
                requestApi.addClient(URL_BASE)
                .addRequest(new RestRequest(resource, Method.GET, DataFormat.Json))
                .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                .buildRequest()
             );
        }
    }
}
