using WebApi.Models;
using WebApi.Utils;

namespace WebApi.Services
{
    //to jest mock serwisu, który ciągnie dane z zewnętrznego webapi
    public class ForecastService(RandomHelper _randomHelper)
    {
        public async Task<WeatherData> GetForecastFor(string city, DateOnly date)
        {
            await Task.Delay(500);
            return new WeatherData
            {
                City = city,
                Date = date,
                TemperatureC = _randomHelper.GetRandomTemperature()
            };
        }

        public async Task<bool> IsServiceHealthy()
        {
            await Task.Delay(500);
            return true;
        }
    }
}
