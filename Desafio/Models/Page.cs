using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Models
{
    public class Page : Register
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
