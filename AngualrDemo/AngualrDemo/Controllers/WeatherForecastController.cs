using AngualrDemo.Models;
using AngualrDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AngualrDemo.Controllers
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

        [HttpGet]
        [Route("test")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("testPost")]
        public IEnumerable<WeatherForecast> Post(object any)
        {
            /*EncryptDecryptGCM.JWTTokenCreation();
            var encrypt= EncryptDecryptGCM.Encrypt("attar@1234");
            var decrypt = EncryptDecryptGCM.Decrypt(encrypt);*/
            //User user = new User() { Id = "1234" };
            //var encrypt = Tokens.GenerateToken(user);
            //var decrypt = Tokens.ValidateToken(encrypt);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("loginPut")]
        public void Put(LoginModel loginModel)
        {

            TokensTest.genarate(loginModel.UserName, loginModel.Password);
        }
    }
}