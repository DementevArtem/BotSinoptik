using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace ParserFisrtProgram.BotTelegram
{
    class Connection
    {
        private ITelegramBotClient _client;
        public Connection()
        {
            _client = new TelegramBotClient("1860532622:AAHg6bIw9AOtZ6rAzV8ewAuX2KVABYZIbIY") { Timeout = TimeSpan.FromSeconds(10) };
        }
        public void InfoAtribut()
        {
            var botAtt = new BotAttribute(_client);

            _client.OnMessage += botAtt.Bot_OnMassage;
            _client.OnMessage += botAtt.Bot_OnMassageStart;

            _client.StartReceiving();
        }
    }
}
