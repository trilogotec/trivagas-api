using System.Threading.Tasks;
using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Notify;

namespace TriVagas.Services.Services
{
    public class PageServer : BaseService , IPageServer
    {
        private readonly IPageRepository _pageRepository;
        private readonly IPageOwnerRepository _pageOwnerRepository;
        public PageServer(
            IPageRepository pageRepository,
            IPageOwnerRepository pageOwnerRepository,
            INotify notify) : base(notify)
        {
            _pageRepository = pageRepository;
            _pageOwnerRepository = pageOwnerRepository;
        }

        public async Task<Page> CreatePage(Company company,User user) 
        {
            var page = new Page(company, user);

            await _pageRepository.Add(page);

            var newPageOwner = new PageUser(page, user);

            await _pageOwnerRepository.Add(newPageOwner);

            return await _pageRepository.GetById(page.Id);
        }
    }
}
