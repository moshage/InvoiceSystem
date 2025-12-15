using NFSystem.Models;
using NFSystem.Notification;
using NFSystem.Utils;

namespace NFSystem.Validator
{
    public class InvoiceValidator : IInvoiceValidator
    {
        public bool Validate(Invoices invoice, INotification notifier)
        {
            if (string.IsNullOrWhiteSpace(invoice.InvoiceNumber))
                notifier.Add("Número da nota fiscal está nula.");

            if (!CnpjValidator.IsValid(invoice.CnpjServiceProvider))
                notifier.Add("CNPJ do Prestador é inválido.");

            if (!CnpjValidator.IsValid(invoice.CnpjTaker))
                notifier.Add("CNPJ do Tomador é inválido.");

            if (invoice.DateIssue == default)
                notifier.Add("Data de Emissão é inválida.");

            if (invoice.TotalAmount <= 0)
                notifier.Add("Valor total da nota deve ser maior que 0 (zero).");

            return !notifier.HasNotifications();
            
        }
    }
}
