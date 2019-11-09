using System;
using TriVagas.Services.Notify;

namespace TriVagas.Services.Services
{
    public abstract class BaseService
    {
        private readonly INotify _notify;
        public BaseService(INotify notify)
        {
            _notify = notify;
        }

        protected void Notify(string message) 
        {
            _notify.Add(new Notification(message));
        }

        protected bool HasNotification() 
        {
            return _notify.Any();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
