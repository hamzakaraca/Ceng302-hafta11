using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Port : IEntity
    {
        public int Id { get; set; }
        public string PortName { get; set; }
        public string Country { get; set; }
    }
}