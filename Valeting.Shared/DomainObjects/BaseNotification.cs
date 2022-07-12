namespace Valeting.Shared.DomainObjects
{
    public class BaseNotification
    {
        private readonly List<Notification> _notifications;

        public BaseNotification()
        {
            _notifications = new List<Notification>();
        }

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
