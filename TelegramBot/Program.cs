using System;
using System.Threading.Tasks;
using Telegram;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
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

                botClient.OnMessage += getMessageAsync;
                //botClient.OnCallbackQuery += getCallBack;
                //botClient.StartReceiving();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }


        private static Task getMainGamePage(Chat userChat)
        {
            InlineKeyboardButton b = new InlineKeyboardButton();
            b.Text = "";
            b.CallbackData = "/forest";
            var k = new InlineKeyboardMarkup(b);
            //await botClient.SendTextMessageAsync(userChat.Id, "")
        }




        private static async System.Threading.Tasks.Task getMessageAsync(object sender, MessageEventArgs e)

        {

            if (e.Message.Text != null)
                switch (e.Message.Text.ToLower())
                {

                    case "/start":
                        //var markup = new ReplyKeyboardMarkup();

                        //KeyboardButton a = new KeyboardButton();
                        //a.Text = "Hello from Game!";

                        //markup.OneTimeKeyboard = true;
                       // botClient.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Text, replyMarkup: markup);
                        await botClient.SendPhotoAsync(e.Message.Chat.Id, "https://st3.depositphotos.com/4216129/18157/v/1600/depositphotos_181573996-stock-illustration-funny-snail-character-cute-green.jpg", $"Hello from Game!");
                        getMainGamePage(e.Message.Chat);
                        break;

                    default:
                        break;
                }

        }

        private static void getQueryMess(object sender, MessageEventArgs e)
        {

            switch (e.CallbackQuery.Data.ToLower())
            {
                case "/forest":
                    {
                        botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id," https://99px.ru/sstorage/53/2016/10/tmb_181716_3034.jpg","$!");
                        break;
                    }



            }





        }
    }

}
