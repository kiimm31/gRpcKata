using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcServiceDemo;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<WeatherForecastService> _logger;
        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            _logger = logger;
        }
        public Task<WeatherForecastReply> GetWeatherForecast(ServerCallContext context)
        {
            return Task.FromResult<WeatherForecastReply>(GetWeather());
        }
        public Task<WeatherForecastReply> GetWeatherForecastForDate(Timestamp date, ServerCallContext context)
        {
            return Task.FromResult<WeatherForecastReply>(GetWeather(date));
        }
        private WeatherForecastReply GetWeather()
        {
            var result = new WeatherForecastReply();
            for (var index = 1; index <= 5; index++)
            {
                result.Result.Add(
                    new WeatherForecast
                    {
                        Date = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(index)),
                        TemperatureC = new Random().Next(-20, 55),
                        Summary = Summaries[new Random().Next(Summaries.Length)],
                        TemperatureF = (int)(32 + (new Random().Next(-20, 55) / 0.5556))
                    }
                );
            }
            return result;
        }
        private WeatherForecastReply GetWeather(Timestamp date)
        {
            var result = new WeatherForecastReply();
            result.Result.Add(
                new WeatherForecast
                {
                    Date = date,
                    TemperatureC = new Random().Next(-20, 55),
                    Summary = Summaries[new Random().Next(Summaries.Length)],
                    TemperatureF = (int)(32 + (new Random().Next(-20, 55) / 0.5556))
                }
            );
            return result;
        }
    }
}