using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace RSASignature
{
    public class ClientServer
    {
        private TcpClient client;

        public ClientServer(string hostName, int host) {
            client = new TcpClient(hostName, host);
        }

        public ClientServer()
        {
            client = new TcpClient();
        }

        public async Task<bool> Connect(string serverIP, int port)
        {
            var connectTask = client.ConnectAsync(serverIP, port);

           // var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(2));

            if (await Task.WhenAny(connectTask, Task.Delay(TimeSpan.FromSeconds(2))) == connectTask)
            {
                if(client.Connected)
                return true;
            }
            return false;
        }

        public void SendObject(TcpClient client, object obj)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending object: " + ex.Message);
            }
        }

        public void Disconnect()
        {
            client?.Close();
        }

        public string GetLocalIPAddress()
        {
            string ipAddress = string.Empty;
            try
            {
                ipAddress = Dns.GetHostEntry(Dns.GetHostName())
                               .AddressList
                               .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                               ?.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting local IP address: " + ex.Message);
            }
            return ipAddress;
        }
    }
}
