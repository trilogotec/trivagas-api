using System;
using System.Collections.Generic;
using System.Text;
using TriVagas.Domain.Models;

namespace TriVagas.Services.Requests
{
    public class PageRegistreRequest
    {
        public Company Company { get; set; }
        public Page Page { get; set; }
        public PageUser PageUser { get; private set; }
       
    }
}
