using System;

namespace TelegramWeatherTestBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WeatherBot weatherBot = new WeatherBot();
            weatherBot.Start();
            Console.ReadKey();
        }
    }
}
