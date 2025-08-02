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
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
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
        [HttpGet("GetTotalPages/{pgSize}")]
        public async Task<IActionResult> GetTotalPages(int pgSize)
        {
            var responseResult = await invoiceService.GetTotalPages(pgSize);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("GetAllPaginatedAsync/{pgSize}/{pgNumber}")]
        public async Task<IActionResult> GetAllPaginatedAsync(int pgSize,int pgNumber)
        {
            var responseResult = await invoiceService.GetAllPaginatedAsync(pgSize, pgNumber);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("GetTotalFilteredPages/{pgSize}/{filterText}")]
        public async Task<IActionResult> GetTotalFilteredPages(int pgSize,string filterText)
        {
            var responseResult = await invoiceService.GetTotalFilteredPages(pgSize, filterText);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("GetAllFilteredPaginatedAsync/{pgSize}/{pgNumber}/{filterText}")]
        public async Task<IActionResult> GetAllFilteredPaginatedAsync(int pgSize, int pgNumber, string filterText)
        {
            var responseResult = await invoiceService.GetAllFilteredPaginatedAsync(pgSize, pgNumber,filterText);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
    }
}
