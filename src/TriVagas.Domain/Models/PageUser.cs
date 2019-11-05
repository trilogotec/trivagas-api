namespace TriVagas.Domain.Models
{
    public class PageUser
    {
        public int PageId { get; set; }
        public Page Page { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}