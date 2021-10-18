using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using WeatherForecast;

namespace TelegramWeatherTestBot
{
    public class WeatherBot
    {
        private static string _token = "1951210088:AAGKlO0bY1CRnEbY5p-Q35k4i4iakO-Orwc";
        private TelegramBotClient _telegramBotClient;
        private Forecaster _forecaster;
        public WeatherBot()
        {
            _telegramBotClient = new TelegramBotClient(_token);
            _telegramBotClient.OnMessage += _telegramBotClient_OnMessage;
            _forecaster = new Forecaster();
        }

        private void _telegramBotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            
            string mesasageText = e.Message.Text;
            string responceMessage;
            if (mesasageText == "/start")
            {
                responceMessage = "Write City name";
            }
            else
            {
                var result = _forecaster.GetWeatherByCityForToomorow(mesasageText);

                if (result != null)
                {
                    responceMessage = result.ToString();
                }
                else
                {
                    responceMessage = "Wrong city name";
                }
            }
            _telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, responceMessage);
        }

        public void Start()
        {
            _telegramBotClient.StartReceiving();
        }
        public void Stop()
        {
            _telegramBotClient.StopReceiving();
        }
    }
}
