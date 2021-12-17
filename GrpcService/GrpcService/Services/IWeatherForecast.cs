using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcServiceDemo;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastReply> GetWeatherForecast(ServerCallContext context);
        Task<WeatherForecastReply> GetWeatherForecastForDate(Timestamp date, ServerCallContext context);
    }
}
