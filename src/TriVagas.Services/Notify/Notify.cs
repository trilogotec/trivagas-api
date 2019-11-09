using System.Collections.Generic;
using System.Linq;

namespace TriVagas.Services.Notify
{
    public class Notify : INotify
    {
        private readonly List<Notification> _notifications;
        public Notify(List<Notification> notifications)
        {
            _notifications = notifications;
        }

        public void Add(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool Any()
        {
           return _notifications.Any();
        }

        public List<Notification> GetAll() 
        {
            return _notifications;
        }
    }
}
