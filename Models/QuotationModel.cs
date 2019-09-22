﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaCargoSRL.Models
{
    public class QuotationModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public MacroRouteModel macroRouteOrigin { get; set; }
        public string routeOrigin { get; set; }
        public MacroRouteModel macroRouteDestination { get; set; }
        public string routeDestination { get; set; }
        public float loadWeight { get; set; }
        public float loadVolume { get; set; }
        public TruckTypeModel truckType { get; set; }
        public float storageCapacity { get; set; }
        public float storageTime { get; set; }
        public string comment { get; set; }

    }
}
