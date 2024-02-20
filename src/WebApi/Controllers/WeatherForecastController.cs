using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController(WeatherService _weatherService) : ControllerBase
    {
        [HttpGet("{city}/{date}")]
        public async Task<IActionResult> GetWeatherData(string city, DateOnly date)
        {
            var result = await _weatherService.GetWeather(city, date);
            if (string.IsNullOrEmpty(result.City))
                return NotFound();
            else
                return Ok(result);
        }

    }
}
