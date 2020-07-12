using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Telegram.Bot;



namespace Status_Bot
{ 
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("1115799018:AAHRZhaBEI1YMoVvKgDgn843Z5iSq7PZs04");
        
        public static void Main(string[] args)
        {

            Console.WriteLine($@"    --------------------------------------------  
   /   ********** Bot Start Work **********    /
  / Bot start working at: {DateTime.Now.ToString()} /
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
                Console.WriteLine($@"Input messages: {e.Message.Text} 

From: {e.Message.Chat.FirstName} Time messages: {DateTime.Now.ToString()}");
            // Output messages
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if(e.Message.Text == "/start")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $@"Вітаю вас! {e.Message.Chat.FirstName}
        Доступні команди на даний час:
                        /status - перевірка статусу серверів
                        /about  - інформація про бота ");
                }
               
                if (e.Message.Text == "/status")
                {
                    Status_Ping PingOut = new Status_Ping();
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $@"Статус  серверів на даний час: |{DateTime.Now.ToLongTimeString()}|

    lib.udau.edu.ua: {PingOut.output}

    moodle.udau.edu.ua: {PingOut.output1}

    www.udau.edu.ua: {PingOut.output2} ");
                }
                if (e.Message.Text == "/about")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $"Тестовий бот, розроблений Денисом Перепелицею для моніторингу стану серверів ");
                }


            }
            
           
        }
        
    }    
}
