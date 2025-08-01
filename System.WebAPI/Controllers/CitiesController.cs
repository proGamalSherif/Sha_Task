using System.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace System.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService citiesService;
        public CitiesController(ICitiesService _citiesService)
        {
            citiesService = _citiesService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var responseResult = await citiesService.GetAllAsync();
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var responseResult = await citiesService.GetByIdAsync(Id);
            if (!responseResult.IsSuccess)
                return NotFound(responseResult.Message);
            return Ok(responseResult);
        }
    }
}
