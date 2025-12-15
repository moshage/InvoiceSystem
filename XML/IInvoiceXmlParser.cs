using NFSystem.Models;

namespace NFSystem.XML
{
    public interface IInvoiceXmlParser
    {
        public Invoices Parse(string xmlContent);
    }
}
