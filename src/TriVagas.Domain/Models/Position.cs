using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Position : BaseEntity
    {
        public Position(string name, User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Name = name;
        }

        // Empty constructor for EF.
        protected Position() { }
        public string Name { get; protected set; }

        public List<Job> Jobs { get; protected set; }
    }
}
