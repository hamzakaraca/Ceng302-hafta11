﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string VehicleSerialNumber { get; set; }
    }
}