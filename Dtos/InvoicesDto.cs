using Microsoft.IdentityModel.Tokens;
using System.Net.Security;

namespace NFSystem.Dtos
{
    public class InvoiceDto
    {
        public string InvoiceNumber { get; set; }
        public string CnpjServiceProvider { get; set; }
        public string CnpjTaker { get; set; }
        public string DateIssue { get; set; }
        public string ServiceDescription { get; set; }
        public decimal TotalAmount { get; set; }
        public string CriationDate { get; set; }

    }
}
