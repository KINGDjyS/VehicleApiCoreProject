using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vehicle.DAL.Entities
{
    public class VehicleMakeEntity
    {
        [Key]
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModelEntity> Models { get; set; }
    }
}
