using System;

namespace TriVagas.Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime LastUpdate { get; protected set; }
        public User LastUpdateBy { get; protected set; }
        public int? LastUpdateById { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public User CreatedBy { get; protected set; }
        public int? CreatedById { get; protected set; }
    }
}
