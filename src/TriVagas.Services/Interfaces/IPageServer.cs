using System;
using TriVagas.Domain.Models;

namespace TriVagas.Services.Interfaces
{
    public interface IPageServer : IDisposable
    {
        Page CreatePage(Company company, User user);
    }
}
