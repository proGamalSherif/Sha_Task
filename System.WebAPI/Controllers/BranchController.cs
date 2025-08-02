using System.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace System.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branchService;
        public BranchController(IBranchService _branchService)
        {
            branchService = _branchService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var responseResult = await branchService.GetAllAsync();
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var responseResult = await branchService.GetByIdAsync(Id);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("GetAllByCityId/{Id}")]
        public async Task<IActionResult> GetAllByCityId(int Id)
        {
            var responseResult = await branchService.GetAllByCityId(Id);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
    }
}
