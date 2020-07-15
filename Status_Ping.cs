using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Telegram.Bot;

namespace Status_Bot
{
    class Status_Ping
    {
        public string lib { get; set; }
        public string moodle { get; set; }
        public string udau { get; set; }

        public Status_Ping()
        {
            lib = Lib();
            moodle = Moodle();
            udau = Udau();
        }

        private static string Lib()
        {
            string message;
            Ping ping = new Ping();
            PingReply pingresult = ping.Send("lib.udau.edu.ua");
            if (pingresult.Status.ToString() == "Success")
            {
                message = ($@"Працює, Ip адреса ({pingresult.Address}) 
        Затримка відповіді = {pingresult.RoundtripTime} ms");
            }
            else
            {
                message = ("Не працює!");
            }
            return message;
        }
        private static string Moodle()
        {
            string message;
            Ping ping = new Ping();
            PingReply pingresult = ping.Send("moodle.udau.edu.ua");
            if (pingresult.Status.ToString() == "Success")
            {
                message = ($@"Працює, Ip адреса ({pingresult.Address}) 
        Затримка відповіді = {pingresult.RoundtripTime} ms ");
            }
            else
            {
                message = ("Не працює!");
            }
            return message;
        }
        private static string Udau()
        {
            string message;
            Ping ping = new Ping();
            PingReply pingresult = ping.Send("www.udau.edu.ua");
            if (pingresult.Status.ToString() == "Success")
            {
                message = ($@"Працює, Ip адреса ({pingresult.Address}) 
        Затримка відповіді = {pingresult.RoundtripTime} ms ");
            }
            else
            {
                message = ("Не працює!");
            }
            return message;
        }
    }
}
