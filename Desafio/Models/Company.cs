using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Models
{
    public class Company : Register
    {
        public string Name { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<UserCompany> LegalRepresentativies { get; set; }
    }
}
