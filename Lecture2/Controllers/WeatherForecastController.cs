using Microsoft.AspNetCore.Mvc;

namespace Lecture2.Controllers;

[ApiController]
/// <summary>
/// ����� - ����������, ��������� �������� ASP.Net Web API
/// ��� �������, ������� ��������� [controller] (WeatherForecast) ����� �������� �� ���� ����������
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
    /// ��������, ��������� �������� ASP.Net Web API
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
    /// �������� GetHelloWorld, �������������� � �������� http://localhost:5130/WeatherForecast/HelloWorld
    /// ������ ���� �� ����� ��������� ������������ �� ���� �� ����������� (http://localhost:5130/WeatherForecast � ����������� ���� �� ��������� /HelloWorld)
    /// </summary>
    /// <returns>Hello world!</returns>
    [HttpGet("HelloWorld")]
    public string GetHelloWorld() {
        return "Hello world!";
    }

    /// <summary>
    /// �������� GetSquare, �������������� � �������� http://localhost:5130/WeatherForecast/Square
    /// �������� ��������� �������� number.
    /// ������ ���� �� ����� ��������� ������������ �� ���� �� ����������� (http://localhost:5130/WeatherForecast � ����������� ���� �� ��������� /Square)
    /// </summary>
    /// <param name="number">����� ��� ���������� � �������</param>
    /// <returns>���������� � ������� �����</returns>
    [HttpGet("Square")]
    public double GetSquare(double number) {
        return Math.Pow(number, 2);
    }
}
