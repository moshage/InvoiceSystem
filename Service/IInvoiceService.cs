using NFSystem.Dtos;
using NFSystem.Results;

namespace NFSystem.Service
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllAsync();
        Task<ImportInvoiceResult> ImportFromXmlAsync(IList<IFormFile> files);
    }
}
