using System;
using System.Collections.Generic;

namespace Domain
{
    public class Page : BaseEntity
    {
        public Company Company { get; set; }
        public List<User> Owners { get; set; }
    }
}
