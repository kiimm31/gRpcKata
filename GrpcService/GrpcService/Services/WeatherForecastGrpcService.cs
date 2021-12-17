using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcServiceDemo;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class WeatherForecastGrpcService : WeatherForcast.WeatherForcastBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<WeatherForecastService> _logger;
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastGrpcService(ILogger<WeatherForecastService> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }
        public override Task<WeatherForecastReply> GetWeatherForecast(Empty request, ServerCallContext context)
        {
            return _weatherForecastService.GetWeatherForecast(context);
        }
        public override Task<WeatherForecastReply> GetWeatherForecastForDate(Timestamp date, ServerCallContext context)
        {
            return _weatherForecastService.GetWeatherForecastForDate(date, context);
        }
    }
}