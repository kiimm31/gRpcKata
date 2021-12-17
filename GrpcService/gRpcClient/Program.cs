using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace gRpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var weatherClient = new WeatherForcast.WeatherForcastClient(channel);
            var request = new Google.Protobuf.WellKnownTypes.Empty();
            var weatherInfo = weatherClient.GetWeatherForecast(request);
            Console.WriteLine("*****Weather forecast for 5 days*****");
            Console.WriteLine(weatherInfo.Result);
            weatherInfo = weatherClient.GetWeatherForecastForDate(Timestamp.FromDateTime(DateTime.UtcNow));
            Console.WriteLine("*****Weather forecast for today*****");
            Console.WriteLine(weatherInfo.Result);
            request = new Google.Protobuf.WellKnownTypes.Empty();
            weatherInfo = await weatherClient.GetWeatherForecastAsync(request);
            Console.WriteLine("*****Weather forecast for 5 days*****");
            Console.WriteLine(weatherInfo.Result);
            weatherInfo = await weatherClient.GetWeatherForecastForDateAsync(Timestamp.FromDateTime(DateTime.UtcNow));
            Console.WriteLine("*****Weather forecast for today*****");
            Console.WriteLine(weatherInfo.Result);
            Console.ReadKey();
        }
    }
}
