using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaCargoSRL.Models.ViewModels
{
    public class QuotationViewModel
    {
        public IEnumerable<ServiceTypeModel> serviceTypes { get; set; }
        public IEnumerable<MacroRouteModel> macroRoutes { get; set; }
        public IEnumerable<TruckTypeModel> trucksTypes { get; set; }

        // recuperar los datos para las unidades de medida
        public IEnumerable<UnitMeasurementModel> umsStorageCapacity { get; set; }
        public IEnumerable<UnitMeasurementModel> umsStorageTime { get; set; }

    }
}