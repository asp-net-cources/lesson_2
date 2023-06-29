using Microsoft.AspNetCore.Mvc;

namespace Lecture2.Controllers;

[ApiController]
/// <summary>
/// Класс - контроллер, созданный шаблоном ASP.Net Web API
/// Все запросы, имеющие приставку [controller] (WeatherForecast) будут попадать на этот контроллер
[Route("[controller]")]
/// </summary>
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger) {
        _logger = logger;
    }

    /// <summary>
    /// Эндпоинт, созданный шаблоном ASP.Net Web API
    /// </summary>
    [HttpGet("GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get() {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    /// <summary>
    /// Эндпоинт GetHelloWorld, сопоставленный с запросом http://localhost:5130/WeatherForecast/HelloWorld
    /// Полный путь до этого эндпоинта складывается из пути до контроллера (http://localhost:5130/WeatherForecast и внутреннего пути до эндпоинтв /HelloWorld)
    /// </summary>
    /// <returns>Hello world!</returns>
    [HttpGet("HelloWorld")]
    public string GetHelloWorld() {
        return "Hello world!";
    }

    /// <summary>
    /// Эндпоинт GetSquare, сопоставленный с запросом http://localhost:5130/WeatherForecast/Square
    /// Эндпоинт принимает аргумент number.
    /// Полный путь до этого эндпоинта складывается из пути до контроллера (http://localhost:5130/WeatherForecast и внутреннего пути до эндпоинтв /Square)
    /// </summary>
    /// <param name="number">Число для возведения в квадрат</param>
    /// <returns>Возведённое в квадрат число</returns>
    [HttpGet("Square")]
    public double GetSquare(double number) {
        return Math.Pow(number, 2);
    }
}
