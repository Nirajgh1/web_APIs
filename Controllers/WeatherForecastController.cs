using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public void insertShop(int shopID, string shopName, int OwnerID)
        {
            Console.WriteLine($"{shopID} shop {shopName}is inserted with owner{OwnerID} in db ");
            //string query = $"INSERT INTO shops(ShopID,Fname,TaxID,OwnerID)VALUES({obj.id},'{obj.name}',{obj.tid},{obj.oid})";
        }

        [HttpPut]
        public void updateShop(int shopID,string shopName)
        {
            Console.WriteLine($"shop is {shopID} updated with new name {shopName}");
        }

        [HttpDelete]
        public void deleteShop(int shopID)
        {
            Console.WriteLine($"shop is deleted with the shopID {shopID}");
        }
    }
}
