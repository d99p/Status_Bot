using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Telegram.Bot;



namespace Status_Bot
{ 
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("1321277709:AAFyxXEJJJLtQpMorl7WBW7PnItxoIefGXc");
        
        public static void Main(string[] args)
        {

            Console.WriteLine("    --------------------------------------------");
            Console.WriteLine("   /   ********** Bot Start Work **********    /");
            Console.WriteLine($"  / Bot start working at: {DateTime.Now.ToString()} /");
            Console.WriteLine(" / Press any key to stop bot.                /");
            Console.WriteLine(" --------------------------------------------");


            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;
            

           
           
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();

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
                if (e.Message.Text == "/Status")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $"Вітаю вас!{e.Message.Chat.FirstName}");

                    Status_Ping PingOut = new Status_Ping();
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $@"Статус наших серверів:

    Репозитарій: {PingOut.output}

    Hosing:  {PingOut.output1}

    Moodle: {PingOut.output2} ");
                }

            }
            
           
        }
        
    }    
}
