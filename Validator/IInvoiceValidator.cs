using NFSystem.Models;
using NFSystem.Notification;

namespace NFSystem.Validator
{
    public interface IInvoiceValidator
    {
        bool Validate(Invoices invoice, INotification notifier);
    }
}
