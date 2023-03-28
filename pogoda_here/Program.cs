using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;

namespace pogoda_here
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"C:\Users\dzono\source\repos\pogoda_here\token.txt";
            string token = System.IO.File.ReadAllText(FilePath);
            var client = new TelegramBotClient(token);
            client.StartReceiving(Update, Error);
            
            Console.ReadLine();
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {

                if (message.Text.ToLower().Contains("/start"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Hi! I'm a bot and i'll help you with weather");
                }
                if (message.Text.ToLower().Contains("/loc"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Please write your location!");
                }
                if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
                {
                    if (update.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                    {
                        var text = update.Message.Text;
                        var id = update.Message.Chat.Id;
                        string? username = update.Message.Chat.Username;
                        Console.WriteLine(text);
                    }
                }
            }
        }
    }
}
