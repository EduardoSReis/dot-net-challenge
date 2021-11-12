using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        TemperatureRepository temperatureRepository = new TemperatureRepository();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemperature(string id)        {
            var result = temperatureRepository.GetTemperature(id);
            return result;            
        }
    }
}
