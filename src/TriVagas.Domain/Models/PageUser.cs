namespace TriVagas.Domain.Models
{
    public class PageUser
    {
        public PageUser(Page page, User owner)
        {
            Page = page;
            Owner = owner;
        }

        protected PageUser() { }
        public int PageId { get; protected set; }
        public Page Page { get; protected set; }

        public int OwnerId { get; protected set; }
        public User Owner { get; protected set; }
    }
}