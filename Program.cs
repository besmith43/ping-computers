using System;
using System.Text;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace ping_computers
{
    class Program
    {
        static void Main(string[] args)
        {
            PingCompsAsync p = new PingCompsAsync();

            p.startPing();
        }
    }

    public class PingCompsAsync
    {
        string[] computers = new string[] {
            "HEND107-M01",
            "FOST410-M01",
            "FOST123-M01",
            "HEND118-M01",
            "HEND320-M01",
            "DANL323-M01",
            "BRUN109-M01",
            "FNDH212A-M01",
            "DANL309-M04",
            "FNDH250-M04",
            "PENN300-M02",
            "PENN301-M01",
            "PENN317-M02",
            "DANL231-M01",
            "PENN205-M03",
            "HEND212A-M01",
            "BRUN243-M01",
            "FNDH250-M05",
            "FOST127-M01",
            "FNDH250-M02",
            "MATT261-M01",
            "HEND208-M01",
            "PENN412-M01",
            "MATT355-M01",
            "PENN214-M01",
            "DANL230-M01",
            "OKLY220-M01",
            "PENN415-M01",
            "PENN313-M01",
            "MATT137-M01",
            "FOST224-M02",
            "HEND116B-M02",
            "HEND104-M02",
            "HEND218C-M01",
            "FNDH168-M01",
            "FNDH221-M01",
            "FOST324-M01",
            "MATT138-M01",
            "FOST221-M02",
            "FNDH250-M03",
            "HEND307B-M01",
            "EVIN109-M01",
            "PENN319-M01",
            "HEND118A-M01",
            "JWB142-M01",
            "PENN108-M01",
            "SOUT235-M01",
            "DANL232-M01",
            "PENN403-M01",
            "HEND116BD-M01",
            "PENN315-M02",
            "HEND312A-M01",
            "FOST316-M01",
            "HEND320-M03",
            "BRUN227A-M01",
            "MATT258-M01",
            "FOST219-M01",
            "HEND218B-M01",
            "HEND314-M01",
            "JWB104-M01",
            "BRUN412A-M01",
            "HEND203A-M01",
            "BRUN318-M01",
            "OKLY224-M01",
            "MATT359-M01",
            "BRUN333-M01",
            "OKLY215B-M02",
            "HEND312B-M01",
            "OKLY228-M02",
            "OKLY225-M01",
            "DANL313-M02",
            "PENN114-M01",
            "FOST412-M03",
            "HEND306A-M01",
            "HEND007-M03",
            "HEND112-M01",
            "OKLY227-M01",
            "PENN207C-M01",
            "KITT202-M01",
            "BRUN235-M03",
            "HEND208E-M02",
            "PENN207-M02",
            "FOST302-M01",
            "PENN303-M01",
            "PENN321-M01",
            "BRUN114-M01",
            "PENN204A-M01",
            "HEND207-M01",
            "HEND116A-M01",
            "BRUN310-M01",
            "BRUN115-M01",
            "HEND204C-M03",
            "BRUN110-M02",
            "FOST219-M02",
            "HEND110-M02",
            "FOST322-M01",
            "FOST412-M02",
            "FOST205-M02",
            "FNDH220-M01",
            "FOST107-M01",
            "HEND218A-M02",
            "FOST303-M01",
            "FOST221-M01",
            "FOST219-M03"
        };

        public async void startPing()
        {
            List<Task> tasks = new List<Task>();

            foreach(var comp in computers)
            {
                tasks.Add(PingAsync(comp));
            }

            Task.WaitAll(tasks.ToArray());
        }

        public static async Task PingAsync(string host)
        {
            try
            {
                var ping = new System.Net.NetworkInformation.Ping();
                var reply = await ping.SendPingAsync(host);

                if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    Console.WriteLine($"{ host } is online");
                }
            }
            catch
            {
                Console.WriteLine($"{ host } is not online");
            }
        }
    }
}
