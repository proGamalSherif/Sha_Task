using System.Application.DTOs.CashierDTOs;
using System.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace System.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashierController : ControllerBase
    {
        private readonly ICashierService cashierService;
        public CashierController(ICashierService _cashierService)
        {
            cashierService = _cashierService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var responseResult = await cashierService.GetAllAsync();
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var responseResult = await cashierService.GetByIdAsync(Id);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("GetTotalPages/{pgSize}")]
        public async Task<IActionResult> GetTotalPages(int pgSize)
        {
            var responseResult = await cashierService.GetTotalPages(pgSize);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("GetAllPaginatedAsync/{pgSize}/{pgNumber}")]
        public async Task<IActionResult> GetAllPaginatedAsync(int pgSize,int pgNumber)
        {
            var responseResult = await cashierService.GetAllPaginatedAsync(pgSize,pgNumber);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(InsertCashierDTO entity)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var responseResult = await cashierService.InsertAsync(entity);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCashierDTO entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var responseResult = await cashierService.UpdateAsync(entity);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var responseResult = await cashierService.DeleteAsync(Id);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
    }
}
