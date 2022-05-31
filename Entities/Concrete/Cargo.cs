using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Cargo : IEntity
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string FromPlace { get; set; }
        public string SendToPlace { get; set; }
        public DateTime SendDate { get; set; } = DateTime.Now;
    }
}
