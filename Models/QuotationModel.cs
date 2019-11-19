using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaCargoSRL.Models
{
    public class QuotationModel
    {
        #region "Fields Database DeltaDB"
        public int id { get; set; }
        // cotizacion relacionado con datos de un cliente (nuevo/antiguo)
        //public ContactDTO contact { get; set; }
        public int idContact { get; set; }
        //public ServiceTypeDTO serviceType { get; set;}
        [Required(ErrorMessage = "Seleccione el Tipo de Servicio")]
        [DisplayName("Servicio")]
        public int idServiceType { get; set; }

        // st : transporte (internacional/nacional)
        //public RouteDTO macroRouteOrigin { get; set; }
        [Display(Name ="Origen")]
        public int? idMacroRouteOrigin { get; set; }

        [Display(Name = "Ciudad", Prompt = "Santa Cruz")]
        public string routeCityOrigin { get; set; }  // no habilitadas para st: transporte nacional

        //public RouteDTO macroRouteDestination { get; set; }
        [DisplayName("Destino")]
        public int? idMacroRouteDestination { get; set; }

        [Display(Name ="Ciudad", Prompt = "La Paz")]
        public string routeCityDestination { get; set; } // no habilitada para st: transporte nacional
        
        //public TruckTypeDTO truckType { get; set; } // no habilitadas para clientes no registradas
        [DisplayName("Tipo de camión")]
        public int? idTruckType { get; set; }

        // para todos st (Excepto el almacenamiento de carga)
        [Display(Name = "Peso", Prompt = "200.34")]
        public decimal? loadWeight { get; set; }
        
        //public UnitMeasurementDTO umLoadWeight { get; set; }
        public int? idUmLoadWeight { get; set; }

        [Display(Name = "Volumen", Prompt = "200")]
        public decimal? loadVolume { get; set; }
        //public UnitMeasurementDTO umLoadVolume { get; set; }
        public int? idUmLoadVolume { get; set; }
        public bool? imo { get; set; } // solo para cotizaciones de clientes antiguos

        // st: almacen de carga
        [Display(Name = "Capacidad de Almacenamiento", Prompt = "150.5")]
        public decimal? storageCapacity { get; set; }
        //public UnitMeasurementDTO umStorageCapacity { get; set; }
        public int? idUmStorageCapacity { get; set; }

        [Display(Name = "Tiempo de almacenamiento", Prompt = "5")]
        public decimal? storageTime { get; set; }
        //public UnitMeasurementDTO umStorageTime { get; set; }
        public int? idUmStorageTime { get; set; }

        // para todos los tipos de servicio
        [Display(Name = "Coméntanos", Prompt = "Hola! Quiero transportar 10 pallets, peso total 20 Tn, en la ruta indicada esta semana...")]
        public string comment { get; set; }
        #endregion

        #region "Fields Model CRM.Leads"
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name ="Nombre Completo", Prompt = "Roberto Peréz")]
        public string name { get; set; }
        
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Empresa", Prompt = "Delta Cargo SRL")]
        public string company_name { get; set; }
        
        [Display(Name = "Correo Electrónico", Prompt = "roberto.perez@gmail.com")]
        public string email_from { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Celular", Prompt = "78055825")]
        public string phone { get; set; }
        // city and country reusability of previus model

        // st: Ruta Urbana SCZ
        [Display(Name = "Dirección", Prompt = "Av. Tte Vega, Barrio Libertad, Calle 1")]
        public string street { get; set; }

        public string kanban_state { get; set; }
        
        public string type { get; set; }
        
        public string description { get; set; } // internal_notes
        #endregion
    }
}
