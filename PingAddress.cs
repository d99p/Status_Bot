using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Status_Bot
{
    public class PingAddress
    {
        public string get_ping { get; set; }
     
        public PingAddress(string set_address)
        {
            set_address = AddressToPing(set_address);       
        }
        private string AddressToPing(string pingaddress)
        {
            string message;
            
            try
            {
                Ping ping = new Ping();
                PingReply pingresult = ping.Send(pingaddress);
                if (pingresult.Status.ToString() == "Success")
                {
                                        
                        message = ($@"Ip адреса ({pingresult.Address}) Статус: {pingresult.Status.ToString()}
        Затримка відповіді = {pingresult.RoundtripTime} ms");
                    
                }
                else
                {
                    message = ("Немає відповіді від сервера.");
                }
                return get_ping = message;
            }
            catch
            {
                message = "Помилка вводу спробуте знову";
            }
            return get_ping = message;
        }
    }
}
