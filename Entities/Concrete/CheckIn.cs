using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CheckIn : IEntity
    {
        public int Id { get; set; }
        public int ShipId { get; set; }
        public int PortId { get; set; }
        public int TaxPaid { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now;
    }
}