using System;
using System.Collections.Generic;
using System.Text;


namespace WeatherForecast
{
    public class Weather
    {
        public string City { get; set; }
        public DateTime Date { get; set; }
        public float Tempreture { get; set; }
        public float Wind { get; set; }
        public double ProbabilityOfPrecipitation { get; set; }

      

        public void SetForecastForToomorow()
        {
             //var result = await GetForecastAsync(new City("ISTANBUL"));
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("  Weather forecast for tomorrow  ");
            stringBuilder.AppendLine("City: " + City);
            stringBuilder.AppendLine("Date: " + Date.Date.ToShortDateString());
            stringBuilder.AppendLine("Tempreture: " + Tempreture.ToString());
            stringBuilder.AppendLine("Wind: " + Wind.ToString());
            stringBuilder.AppendLine("Probability of precipitation: " + ProbabilityOfPrecipitation.ToString());
            return stringBuilder.ToString();
        }
    }
}
