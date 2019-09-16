﻿using Microsoft.AspNetCore.Mvc;
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

        [DisplayName("Numero de Licencia")]
        public long nroLicense { get; set; }
        [DisplayName("Nombres")]
        public string fullname { get; set; }
        [DisplayName("Apellidos")]
        public string lastname { get; set; }
        [DisplayName("Empresa")]
        public string company { get; set; }
        [DisplayName("Telefono")]
        public string phone { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int id_truckType { get; set; } // FK -> Tipo Camion
        //[HiddenInput(DisplayValue = false)]
        public List<RouteModel> ids_Route { get; set; } // 





    }
}