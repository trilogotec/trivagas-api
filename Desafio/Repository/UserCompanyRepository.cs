using Desafio.Context;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Repository
{
    public class UserCompanyRepository
    {
        private readonly DesafioContext _context;
        private readonly DbSet<UserCompany> _entity;

        public UserCompanyRepository(DesafioContext context)
        {
            _context = context;
            _entity = _context.UserCompanies;
        }

        public UserCompany Add(UserCompany userCompany)
        {
            _entity.Add(userCompany);
            _context.SaveChanges();
            return userCompany;
        }

        public bool RepresentCompany(int userId, int companyId)
        {
            return _entity.Any(a => a.UserId == userId && a.CompanyId == companyId);
        }
    }
}
