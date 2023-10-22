using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_4_2
{
    public interface IConnectable
    {
        void Connect(Computer computer);
        void Disconnect(Computer computer);
        void TransmitData(Computer source, Computer destination, string data);
    }

    public class Computer
    {
        public string IPAddress { get; set; } = "192.168.0.1";
        public int Power { get; set; } = 500;
        public string OperatingSystem { get; set; } = "Windows 11";
    }

    public class Server : Computer, IConnectable
    {
        public void Connect(Computer computer)
        {
            Console.WriteLine($"Server connected to {computer.IPAddress}");
        }

        public void Disconnect(Computer computer)
        {
            Console.WriteLine($"Server disconnected from {computer.IPAddress}");
        }

        public void TransmitData(Computer source, Computer destination, string data)
        {
            Console.WriteLine($"Data transmitted from {source.IPAddress} to {destination.IPAddress}: {data}");
        }
    }

    public class Workstation : Computer, IConnectable
    {
        public void Connect(Computer computer)
        {
            Console.WriteLine($"Workstation connected to {computer.IPAddress}");
        }

        public void Disconnect(Computer computer)
        {
            Console.WriteLine($"Workstation disconnected from {computer.IPAddress}");
        }

        public void TransmitData(Computer source, Computer destination, string data)
        {
            Console.WriteLine($"Data transmitted from {source.IPAddress} to {destination.IPAddress}: {data}");
        }
    }

    public class Router : Computer, IConnectable
    {
        public void Connect(Computer computer)
        {
            Console.WriteLine($"Router connected to {computer.IPAddress}");
        }

        public void Disconnect(Computer computer)
        {
            Console.WriteLine($"Router disconnected from {computer.IPAddress}");
        }

        public void TransmitData(Computer source, Computer destination, string data)
        {
            Console.WriteLine($"Data transmitted from {source.IPAddress} to {destination.IPAddress}: {data}");
        }
    }

    public class Network
    {
        public List<Computer> Computers { get; set; }

        public void SimulateInteractions()
        {
            // Створення об'єктів комп'ютерів
            Server server = new Server
            {
                IPAddress = "192.168.0.2",
                Power = 800,
                OperatingSystem = "Windows Server 2019"
            };

            Workstation workstation = new Workstation
            {
                IPAddress = "192.168.0.3",
                Power = 600,
                OperatingSystem = "Windows 10"
            };

            Router router = new Router
            {
                IPAddress = "192.168.0.1",
                Power = 1000,
                OperatingSystem = "Custom Router OS"
            };

            // З'єднання комп'ютерів
            server.Connect(workstation);
            router.Connect(server);
            workstation.Connect(router);

            // Передача даних
            server.TransmitData(server, workstation, "Sample data");

            // Відключення комп'ютерів
            workstation.Disconnect(router);
            router.Disconnect(server);
            server.Disconnect(workstation);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network();
            network.Computers = new List<Computer>
        {
            new Server
            {
                IPAddress = "192.168.0.2",
                Power = 800,
                OperatingSystem = "Windows Server 2019"
            },
            new Workstation
            {
                IPAddress = "192.168.0.3",
                Power = 600,
                OperatingSystem = "Windows 10"
            },
            new Router
            {
                IPAddress = "192.168.0.1",
                Power = 1000,
                OperatingSystem = "Custom Router OS"
            }
        };

            network.SimulateInteractions();
        }
    }
}
