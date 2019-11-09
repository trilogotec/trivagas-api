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

        public Page CreatePage(Company company,User user) 
        {
            var page = new Page(company, user);

            _pageRepository.Add(page);

            var newPageOwner = new PageUser 
            {
                PageId = page.Id,
                Page = page,
                OwnerId = page.CreatedBy.Id,
                Owner = page.CreatedBy
            };

            _pageOwnerRepository.Add(newPageOwner);

            return _pageRepository.GetById(page.Id);
        }
    }
}
