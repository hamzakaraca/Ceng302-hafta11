using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Mission : IEntity
    {
        public int Id { get; set; }
        public string MissionClass { get; set; }
    }
}
