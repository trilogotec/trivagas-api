using System.Collections.Generic;

namespace TriVagas.Services.Notify
{
    public interface INotify
    {
        void Add(Notification notification);
        bool Any();
        List<Notification> GetAll();
    }
}
