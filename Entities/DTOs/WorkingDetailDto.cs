using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class WorkingDetailDto:IDto
    {
        public int WorkingId { get; set; }
        public string PortName { get; set; }
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
    }
}
