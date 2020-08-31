using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Telegram.Bot;



namespace Status_Bot
{ 
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("Token");
        
        public static void Main()
        {

            Console.WriteLine($@"    --------------------------------------------  
   /   ********** Bot Start Work **********    /
  / Bot start working at: {DateTime.Now} /
 / Press  ""X""  key to stop bot.              /
 --------------------------------------------");

            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;

            // Bot on or off
            Bot.StartReceiving();
            while (Console.ReadKey(true).Key != ConsoleKey.X) 
            {
                Bot.StopReceiving();
            }
            

        }
        
        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            //Input messages
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                Console.WriteLine($@"Input message: {e.Message.Text} 

    From: {e.Message.From.FirstName} Time message: {e.Message.Date}");
            }

            // Output messages
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text.StartsWith("/start"))
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $@"
        Вітаю! {e.Message.From.FirstName}
        Доступні команди на даний час:
                        /status - перевірка статусу серверів
                        /ping   - пінг веденої ip адреси, приклад ""ping google.com""
                        /about  - інформація про бота");
                }
                else if (e.Message.Text.StartsWith("/status"))
                {
                    Status_Ping PingOut = new Status_Ping();
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $@"Статус  серверів на даний час: |{DateTime.Now.ToLongTimeString()}|

    lib.udau.edu.ua: {PingOut.lib}

    moodle.udau.edu.ua: {PingOut.moodle}

    www.udau.edu.ua: {PingOut.udau}");
                }
                else if(e.Message.Text.StartsWith("/ping"))
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $@"Перевірка {e.Message.Text.Substring(5)}");
                  
                    string textWithoutCommand = e.Message.Text.Substring(6);
                    PingAddress address = new PingAddress(textWithoutCommand);
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $"{address.get_ping}");
                  
                }
                else if (e.Message.Text.StartsWith("/about"))
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, @"Bot status is designed to monitor servers and more. 
    Creator: Denis Perepelytsia 
    linkedin: https://www.linkedin.com/in/denys-perepelytsia/ ");
                }



            }


        }

    }
}
