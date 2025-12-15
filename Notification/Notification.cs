namespace NFSystem.Notification
{
    public class Notifier : INotification
    {
        private readonly List<string> _notifications = new();
        public void Add(string message)
        {
            _notifications.Add(message);
        }
        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public IReadOnlyCollection<string> GetNotifications()
        {
            return _notifications.AsReadOnly();
        }

    }
}
