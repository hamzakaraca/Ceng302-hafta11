using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CheckOut : IEntity
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int PortId { get; set; }
        public DateTime ExitDate { get; set; }
    }
}
