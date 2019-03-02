using System;
using Telegram;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Program
    {

        static TelegramBotClient botClient;

        static void Main(string[] args)
        {
            try
            {
                botClient = new TelegramBotClient("787820791:AAHZ_GBXzPjgKtK6LhZiuHKp58OYO9CG-oA");
                var bot = botClient.GetMeAsync().Result;
                Console.WriteLine(bot.Username);

                botClient.OnMessage += getMessage;
                //botClient.OnCallbackQuery += getCallBack;
                //botClient.StartReceiving();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }


        private static void getMessage(object sender, MessageEventArgs e)

        {

            if (e.Message.Text != null)
                switch (e.Message.Text.ToLower())
            {
                
                case "/reply":
                    var markup = new ReplyKeyboardMarkup();

                    KeyboardButton a = new KeyboardButton();
                     a.Text= "Hello from Game!";

                   markup.OneTimeKeyboard = true;
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Text, replyMarkup: markup);
                    botClient.SendPhotoAsync(e.Message.Chat.Id, e.Message.Text, replyMarkup: markup);
                    break;
               
                default:
                    break;
            }
           


        }


    }

}
