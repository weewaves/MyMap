﻿using MyMap.DataModel.Domain;
using System;

namespace MyMap.Domain
{
    public class Area : DomainBase
    {
        public Area()
        {
        }

        public string Name { get; set; }

        public int Type { get; set; }
    }
}
