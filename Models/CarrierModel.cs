using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaCargoSRL.Models
{
    public class CarrierModel
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Range(0,int.MaxValue)]
        [Display(Name = "Numero de Licencia", Prompt = "4512581")]
        public long nroLicense { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombres", Prompt = "Ej. Victor")]
        public string fullname { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellidos", Prompt = "Padilla")]
        public string lastname { get; set; }

        [Display(Name = "Empresa", Prompt = "Delta Transporte")]
        public string company { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono", Prompt = "77350000")]
        public string phone { get; set; }

        [Required]
        [Display(Name ="Correo Electrónico", Prompt = "victorpadilla@outlook.com")]
        public string email { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Tipo de Camión")]
        public int id_truckType { get; set; } // FK -> Tipo Camion

        public int id_membership { get; set; }

        //[HiddenInput(DisplayValue = false)]
        // Analizar esta seccion para reemplazar solo con un arreglo de Id's
        [DisplayName("Rutas Transitadas")]
        public List<MacroRouteModel> ids_Route { get; set; } // 





    }
}
