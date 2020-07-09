using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Telegram.Bot;

namespace Status_Bot
{
    class Status_Ping
    {
        public string output { get; set; }
        public string output1 { get; set; }
        public string output2 { get; set; }

        public Status_Ping()
        {
            output = Ping();
            output1 = Ping1();
            output2 = Ping2();
        }

        private static string Ping()
        {
            string message;
            Ping ping = new Ping();
            PingReply pingresult = ping.Send("91.202.144.109");
            if (pingresult.Status.ToString() == "Success")
            {
                message = ($@"Працює ip адреса ({pingresult.Address.ToString()}) Затримка відповіді = { pingresult.RoundtripTime.ToString()} ms");
            }
            else
            {
                message = ("Не працює! ");
            }
            return message;
        }
        private static string Ping1()
        {
            string message;
            Ping ping = new Ping();
            PingReply pingresult = ping.Send("93.190.44.166");
            if (pingresult.Status.ToString() == "Success")
            {
                message = ($@"Працює ip адреса ({pingresult.Address.ToString()}) Затримка відповіді = { pingresult.RoundtripTime.ToString()} ms ");
            }
            else
            {
                message = ("Не працює! ");
            }
            return message;
        }
        private static string Ping2()
        {
            string message;
            Ping ping = new Ping();
            PingReply pingresult = ping.Send("10.11.29.6");
            if (pingresult.Status.ToString() == "Success")
            {
                message = ($@"Працює ip адреса ({pingresult.Address.ToString()}) Затримка відповіді = { pingresult.RoundtripTime.ToString()} ms ");
            }
            else
            {
                message = ("Не працює! ");
            }
            return message;
        }
    }
}
