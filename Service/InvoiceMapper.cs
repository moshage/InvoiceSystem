using NFSystem.Dtos;
using NFSystem.Models;

namespace NFSystem.Service
{
    public static class InvoiceMapper
    {
        public static InvoiceDto ToDto(Invoices invoice)
        {
            return new InvoiceDto
            {
                InvoiceNumber = invoice.InvoiceNumber,
                CnpjServiceProvider = invoice.CnpjServiceProvider,
                CnpjTaker = invoice.CnpjTaker,
                DateIssue = invoice.DateIssue.ToString("yyyy-MM-dd"),
                ServiceDescription = invoice.ServiceDescription,
                TotalAmount = invoice.TotalAmount,
                CriationDate = invoice.CriationDate.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }
    }
}
