using System;

namespace TriVagas.Domain.Models
{
    public class State : BaseEntity
    {
        public State(string name, User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Name = name;
        }
        
        // Empty constructor for EF.
        protected State(){}
        public string Name { get; set; }
    }
}
