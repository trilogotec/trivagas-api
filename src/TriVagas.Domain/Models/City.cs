using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public State State { get; set; }
    }
}
