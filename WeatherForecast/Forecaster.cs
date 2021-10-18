using Awesomio.NET.Models.CurrentWeather;
using Awesomio.Weather.NET;
using Awesomio.Weather.NET.Enums;
using Awesomio.Weather.NET.Models.OneCall;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class Forecaster
    {
        private static string _apiKey = "3fe4d1db6824e471596f32774d796720";
        private WeatherClient _weatherClient;
        public Forecaster()
        {
            _weatherClient = new WeatherClient(_apiKey);
        }

        public Weather GetWeatherByCityForToomorow(string cityName)
        {
            Weather weather = new Weather();
            Coord coord;
            try
            {
                var result = _weatherClient.GetCurrentWeatherAsync<CurrrentWeatherModel>(cityName, "en").Result;
                coord = result.Coord;
                OneCallExclude[] oneCallExcludes = { OneCallExclude.Current, OneCallExclude.Hourly };
                OneCallModel dataOneCall = _weatherClient.GetOneCallApiAsync<OneCallModel>(coord.Lat, coord.Lon, "en", oneCallExcludes).Result;
                var dayly = dataOneCall.Daily;
                var res = dayly[1];
                DateTime dateTime = new DateTime(res.Dt);
                weather.City = cityName;
                weather.Date = DateTime.Today.AddDays(1);
                weather.Tempreture = (float)res.Temp.Day;
                weather.Wind = (float)res.WindSpeed;
                weather.ProbabilityOfPrecipitation = res.Pop;
            }
            catch
            {
                return null;
            }
           

            return weather;
        }
    }
}
