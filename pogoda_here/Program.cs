using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace pogoda_here
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"C:\Users\dzono\source\repos\pogoda_here\token.txt";
            string token = System.IO.File.ReadAllText(FilePath);
            var client = new TelegramBotClient(token) ;
            client.StartReceiving(Update, Error);
            
            Console.ReadLine();
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken CansToken)
        {
            var message = update.Message;
            if (message.Text != null)
            {

                if (message.Text.ToLower().Contains("/start"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Hi! I'm a bot and i'll help you with weather");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Please, write /keyboard");
                }
                else if(message.Text.ToLower().Contains("/keyboard"))
                {
                    ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new KeyboardButton[][]
                    {
                        new KeyboardButton[] { new KeyboardButton("Choose location"), new KeyboardButton("Weather forecast") },
                        new KeyboardButton[] { new KeyboardButton("for feature"), new KeyboardButton("for feature21") }
                    });
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Choose a option",replyMarkup: keyboard);
                }
                
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Enter your location");
                        var text = update.Message.Text;
                        var id = update.Message.Chat.Id;
                        string? username = update.Message.Chat.Username;
                        Console.WriteLine(text);
                        
                

                //if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message && update.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                //{
                //    var text = update.Message.Text;
                //    var id = update.Message.Chat.Id;
                //    string? username = update.Message.Chat.Username;
                //    Console.WriteLine(text);
                //}
            }
        }

    }

}

