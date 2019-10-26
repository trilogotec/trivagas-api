using System;
using System.Collections.Generic;

namespace Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public State State { get; set; }
    }
}
