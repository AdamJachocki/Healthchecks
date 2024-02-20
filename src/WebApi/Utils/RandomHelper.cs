namespace WebApi.Utils
{
    public class RandomHelper
    {
        private static Random _random = new Random();

        public int GetRandomTemperature()
        {
            return _random.Next(-10, 30);
        }
    }
}
