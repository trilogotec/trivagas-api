using System;
using System.Collections.Generic;
using System.Text;
using TriVagas.Domain.Models;

namespace TriVagas.Services.Responses
{
    public class CompanyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public string LinkedIn { get; set; }
    }
}
