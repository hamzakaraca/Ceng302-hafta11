using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Ship : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Curator { get; set; }
        public string NumberOfPerson { get; set; }
        public string Company { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public DateTime ExitDate { get; set; }
    }
}