using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Working : IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PortId { get; set; }
        public int Salary { get; set; }

    }
}
