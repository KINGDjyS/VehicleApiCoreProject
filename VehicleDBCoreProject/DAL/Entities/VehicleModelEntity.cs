using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class VehicleModelEntity
    {
        [Key]
        public int VehicleModelId { get; set; }
        
        public string Name { get; set; }
        public string Abrv { get; set; }

        public int VehicleMakeId { get; set; }
        public virtual VehicleMakeEntity Maker { get; set; }
    }
}
