namespace NFSystem.Notification
{
    public interface INotification
    {
        void Add(string message);
        bool HasNotifications();
        IReadOnlyCollection<string> GetNotifications();
    }
}
