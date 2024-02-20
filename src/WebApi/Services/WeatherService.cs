using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using WebApi.Models;

namespace WebApi.Services
{
    public class WeatherService(ForecastService _forecastService, 
        AppDbContext _dbContext)
    {
        public async Task<WeatherData> GetWeather(string city, DateOnly date)
        {
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            if (date < now)
                return await GetArchiveData(city, date);
            else
                return await _forecastService.GetForecastFor(city, date);
        }

        private async Task<WeatherData> GetArchiveData(string city, DateOnly date)
        {
            var query = _dbContext.WeatherArchives.Where(x => x.City == city.ToUpper() && x.Date == date);
            var result = await query.FirstOrDefaultAsync();

            if (result != null)
                return new WeatherData
                {
                    City = result.City,
                    Date = result.Date,
                    TemperatureC = result.TemperatureC
                };
            else
                return new WeatherData();
        }
    }
}
