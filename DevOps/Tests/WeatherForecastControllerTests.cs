using System;
using System.Collections.Generic;
using System.Linq;
using DevOps.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DevOps.Tests
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _controller;
        private readonly Mock<ILogger<WeatherForecastController>> _mockLogger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastControllerTests()
        {
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(_mockLogger.Object);
        }

        [Fact]
        public void Get_ReturnsExpectedWeatherForecasts()
        {
            // Act
            var result = _controller.Get();

            // Assert
            var forecasts = Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.Equal(5, forecasts.Count());

            foreach (var forecast in forecasts)
            {
                Assert.InRange(forecast.TemperatureC, -20, 55);
                Assert.Contains(forecast.Summary, Summaries);
            }
        }
    }
}
