using Microsoft.AspNetCore.Mvc;
using NFSystem.Dtos;
using NFSystem.Service;

namespace NFSystem.Controllers
{
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {            
            _invoiceService = invoiceService;
        }

        [HttpGet("notas")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> Get()
        {
            var invoice = await _invoiceService.GetAllAsync();
            return Ok(invoice);
        }

        [HttpPost("ImportFiles")]
        public async Task<IActionResult> Import([FromForm] ImportInvoicesDto dto)
        {
            if(dto == null || !dto.FilesXml.Any())
            {
                return BadRequest("Selecione ao menos um arquivo do tipo xml.");
            }

            var result = await _invoiceService.ImportFromXmlAsync(dto.FilesXml);

            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
