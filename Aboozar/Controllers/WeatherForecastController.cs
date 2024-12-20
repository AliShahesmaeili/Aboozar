using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Aboozar.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IStringLocalizer<WeatherForecastController> _localizer;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IStringLocalizer<WeatherForecastController> localizer)
    {
        _logger = logger;
        _localizer = localizer;
    }


    [HttpGet("GetTime")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
    public string GetTime()
    {
        return DateTime.Now.Millisecond.ToString();
    }

    [HttpGet("GetWeatherForecast")]
    public List<WeatherForecast> Get()
    {
        var weatherForecasts = new List<WeatherForecast>();

        weatherForecasts.Add(new()
        {
            Summary = _localizer["text1"].Value,
            Date = DateOnly.MaxValue,
            TemperatureC = 20
        });

        weatherForecasts.Add(new()
        {
            Summary = _localizer["text1"].Value,
            Date = DateOnly.MinValue,
            TemperatureC = 25
        });


        return weatherForecasts;
    }
}
