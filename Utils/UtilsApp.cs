using DeltaCargoSRL.Models;
using DeltaCargoSRL.Models.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaCargoSRL.Utils
{
    public class UtilsApp
    {

        public static string URL_BASE { get; private set; }

        public static void initVarEnviroment(DevelopmentEnvironment environment = DevelopmentEnvironment.IISExpressServer)
        {
            switch (environment)
            {
                case DevelopmentEnvironment.IISExpressServer:
                    URL_BASE = "https://localhost:44333/api/v1/";
                    break;
                case DevelopmentEnvironment.AzureServer:
                    URL_BASE = "https://deltacargoapi.azurewebsites.net/api/v1/";
                    break;
                case DevelopmentEnvironment.IISServer:
                    //URL_BASE = "http://deltacargoapi.azurewebsites.net/api/v1/";
                    break;
                default:
                    break;
            }
        }


        public static bool isNull<T>(T obj) => obj == null;

        public static string serializeJSON<T>(T value) => JsonConvert.SerializeObject(value);

        public static T deserializeJSON<T>(string jsonValue) => JsonConvert.DeserializeObject<T>(jsonValue);

        #region "Composicion de Modelos a partir de otros modelos"
        public static ClientModel getClientFromQuotation(QuotationModel quotation)
        {
            ClientModel resultModel = new ClientModel();
            List<string> splitNames = quotation.name.Split(' ').ToList();
            // validar posteriormente esta logica para obtener los nombres
            if (!isNull(splitNames))
            {
                resultModel.fullname = splitNames[0];
                if (splitNames.Count > 1)
                {
                    resultModel.lastname = splitNames[1];
                }
            }
            resultModel.phone = quotation.phone;
            resultModel.company = quotation.company_name;
            resultModel.id_membership = 1; //  Empresa Afiliad => Delta Cargo
            return resultModel;
        }
            

        #endregion

    }
}
