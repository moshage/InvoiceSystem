using NFSystem.Models;
using System.Xml.Linq;

namespace NFSystem.XML
{
    public class InvoiceXmlParser : IInvoiceXmlParser
    {
        public Invoices Parse(string xmlContent)
        {
            var doc = XDocument.Parse(xmlContent);

            return new Invoices
            {
                InvoiceNumber = doc.Root?.Element("Numero")?.Value,
                CnpjServiceProvider = doc.Root?.Element("Prestador")?.Element("CNPJ").Value,
                CnpjTaker = doc.Root?.Element("Tomador")?.Element("CNPJ").Value,
                DateIssue = DateOnly.TryParse(doc.Root?.Element("DataEmissao").Value, out var date) ? date : default,
                ServiceDescription = doc.Root?.Element("Servico")?.Element("Descricao").Value,
                TotalAmount = decimal.TryParse(doc.Root?.Element("Servico")?.Element("Valor").Value, out var value) ? value : 0
            };
        }
    }
}
