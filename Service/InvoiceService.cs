using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NFSystem.Data;
using NFSystem.Dtos;
using NFSystem.Notification;
using NFSystem.Results;
using NFSystem.Validator;
using NFSystem.XML;
using System.Net.WebSockets;
using System.Xml;

namespace NFSystem.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceDbContext _context;
        private readonly IInvoiceXmlParser _parser;
        private readonly IInvoiceValidator _validator;
        public InvoiceService(InvoiceDbContext context, IInvoiceXmlParser parser, IInvoiceValidator validator)
        {
            _context = context;
            _parser = parser;
            _validator = validator;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
        {
            var list = await _context.ServiceInvoices
                .OrderByDescending(n => n.CriationDate)
                .ToListAsync();

            return list.Select(InvoiceMapper.ToDto);
        }

        public async Task<ImportInvoiceResult> ImportFromXmlAsync(IList<IFormFile> files)
        {
            var result = new ImportInvoiceResult();

            foreach (var filesXml in files)
            {
                var notifier = new Notifier();
                try
                {
                    if (!filesXml.FileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        result.AddError(filesXml.FileName, "Arquivo não é do tipo .xml.", ImportErrorType.InvalidFormat);
                        continue;
                    }

                    var reader = new StreamReader(filesXml.OpenReadStream());
                    var xmlContent = await reader.ReadToEndAsync();

                    var invoice = _parser.Parse(xmlContent);

                    var isValid = _validator.Validate(invoice, notifier);

                    if (!isValid) {
                        result.AddError(filesXml.FileName, string.Join("; ", notifier.GetNotifications()) , ImportErrorType.Validation);
                        continue;
                    }

                    _context.ServiceInvoices.Add(invoice);
                    result.AddSuccess(filesXml.FileName, invoice.InvoiceNumber);

                }
                catch (Exception ex)
                {
                    result.AddError(filesXml.FileName, "", ImportErrorType.Parsing);
                    continue;                                        
                }

            }

            if (result.HasSuccess)
                await _context.SaveChangesAsync();

            return result;
        }
    }
}
