using System;

namespace TriVagas.Domain.Models
{
    public class City : BaseEntity
    {
        public City(string name, State state, User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Name = name;
            State = state;
        }

        // Empty constructor for EF.
        protected City(){}
        public string Name { get; protected set; }
        public State State { get; protected set; }
    }
}
