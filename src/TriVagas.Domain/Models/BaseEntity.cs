using System;

namespace TriVagas.Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastUpdate { get; set; }
        public User LastUpdateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public User CreatedBy { get; set; }
    }
}
