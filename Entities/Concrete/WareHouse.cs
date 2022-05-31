using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class WareHouse : IEntity
    {
        public int Id { get; set; }
        public int PortId { get; set; }
        public string WareHouseName { get; set; }
    }
}
