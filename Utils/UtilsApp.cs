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

        public static void initVarEnviroment(string environment)
        {
            switch (environment)
            {
                case "developing":
                    URL_BASE = "https://localhost:44333/api/v1/";
                    break;
                case "local production":
                    URL_BASE = "";
                    break;
                case "cloud production":
                    break;
            }
        }


        public static bool isNull<T>(T obj) => obj == null;

        public static string serializeJSON<T>(T valueObject) => JsonConvert.SerializeObject(valueObject);

        public static T deserializeJSON<T>(string jsonValue) => JsonConvert.DeserializeObject<T>(jsonValue);

    }
}
