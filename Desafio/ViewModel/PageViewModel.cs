using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.ViewModel
{
    public class PageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public UserViewModel Owner { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }
    }
}
