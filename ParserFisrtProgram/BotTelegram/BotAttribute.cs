using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ParserFisrtProgram.BotTelegram
{
    class BotAttribute
    {
        public static ITelegramBotClient botClient;

	public BotAttribute(ITelegramBotClient client)
        {
            botClient = client;
        }
	public void Bot_OnMassage(object sender, MessageEventArgs e)
	{
		var text = e?.Message?.Text;
		if (text == null)
			return;
		Console.WriteLine($"Your text: {text} in chat '{e.Message.Chat.Id}'");
	}
	public async void Bot_OnMassageStart(object sender, MessageEventArgs e)
	{	
            switch (e.Message.Text)
            {
                case "/start":
                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, $"Привіт! Мене звуть карманним синоптиком🌧. Буду радий тобі допомогти у пошуках вірної іноформації про погоду!🌎🌍🌏\n", ParseMode.Markdown);
                    break;
                case "/search":
			await RequestContactAndLocationUser(e.Message);
			string text = "";
			var mre = new ManualResetEvent(false);
			EventHandler<MessageEventArgs> mHandler = async (sender, e) =>
			{
				text = e.Message.Text.ToLower();
				var search = new SearchData();
				search.address = "https://ua.sinoptik.ua/погода-" + text;

				Console.WriteLine(search.address);
				await search.Data();

				foreach (var item in search.data)
				{
					string[] arr = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
					await botClient.SendTextMessageAsync(e.Message.Chat.Id, $"День: {arr[0]};\nЧисло: {arr[1]} {arr[2]};\nТемпература: {arr[3]} {arr[4]} - {arr[5]} {arr[6]};", ParseMode.Markdown);
				}
			};

			botClient.OnMessage += mHandler;
			mre.WaitOne();
			botClient.OnMessage -= mHandler;

			break;
		default:
                    break;
            }
	}
	static async Task RequestContactAndLocationUser(Message message)
	{
		var RequestReplyKeyboard = new ReplyKeyboardMarkup();
		RequestReplyKeyboard.Keyboard = new KeyboardButton[][]
		{
			new KeyboardButton[]
			{
				new KeyboardButton("Івано-Франківськ")
			},
			new KeyboardButton[]
			{
				new KeyboardButton("Київ")
			},
			new KeyboardButton[]
			{
				new KeyboardButton("Львів")
			},
			new KeyboardButton[]
			{
				new KeyboardButton("Полтава")
			}
		};

		await botClient.SendTextMessageAsync(
			chatId: message.Chat.Id,
			text: "Оберіть кнопку дії:",
			replyMarkup: RequestReplyKeyboard);
		}
	}
}
