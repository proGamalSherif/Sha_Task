using System.Application.DTOs.InvoiceDTOs;
using System.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace System.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        public InvoiceController(IInvoiceService _invoiceService)
        {
            invoiceService = _invoiceService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var responseResult = await invoiceService.GetAllInvoicesAsync();
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var responseResult = await invoiceService.GetInvoiceByIdAsync(Id);
            if(!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(InsertInvoiceDTO entity)
        {
            var responseResult = await invoiceService.AddInvoiceAsync(entity);
            if(!responseResult.IsSuccess)
                return BadRequest(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateInvoiceDTO entity)
        {
            var responseResult = await invoiceService.UpdateInvoiceAsync(entity);
            if (!responseResult.IsSuccess)
                return BadRequest(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(long Id)
        {
            var responseResult = await invoiceService.DeleteInvoiceAsync(Id);
            if (!responseResult.IsSuccess)
                return BadRequest(responseResult.Message);
            return Ok(responseResult);
        }
    }
}
