using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.ViewModel
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<PageViewModel> Pages { get; set; }
        //user company era para estar aqui
    }
}
