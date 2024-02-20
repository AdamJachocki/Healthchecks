namespace WebApi.DAL
{
    public class WeatherDbModel
    {
        public Guid Id {  get; set; }
        public string City { get; set; }
        public DateOnly Date {  get; set; }
        public int TemperatureC {  get; set; }
    }
}
