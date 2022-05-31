using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Storage : IEntity
    {
        public int Id { get; set; }
        public int PortId { get; set; }
        public int CargoId { get; set; }
        public string Block { get; set; }
        public string Peron { get; set; }
        public string Row { get; set; }
        public string Floor { get; set; }
    }
}