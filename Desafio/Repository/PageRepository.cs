using Desafio.Context;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Repository
{
    public class PageRepository : Repository<Page>
    {
        public PageRepository(DesafioContext context) : base(context)
        {

        }

        public override Page GetById(int id)
        {
            return _entity.Include(a => a.Owner).Include(a => a.Company).FirstOrDefault(a => a.Id == id);
        }
    }
}
