using System.Collections.Generic;

namespace Desafio.Models
{
    public class User : Register
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<UserCompany> Companies { get; set; }
    }
}
