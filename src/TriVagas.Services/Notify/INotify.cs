using System.Collections.Generic;
using System.Threading.Tasks;

namespace TriVagas.Services.Notify
{
    public interface INotify
    {
        void Add(Notification notification);
        bool Any();
        List<Notification> GetAll();
    }
}
