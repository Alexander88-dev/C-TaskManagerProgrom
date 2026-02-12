using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;


namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();

            Console.WriteLine("Server statted on port 5000");

            while (true) 
            {
                TcpClient client = listener.AcceptTcpClient();
                Task.Run(() => HandleClient(client));
            }
        }

        static void HandleClient(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream()) 
                using (StreamReader reader = new StreamReader(stream))   
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    while (true) 
                    {
                        string request = reader.ReadLine();
                    
                        if(request == null) 
                        {
                            Console.WriteLine("Клиент вышел");
                            break;
                        }
                        if (request.StartsWith("LOGIN")) 
                        {
                            string[] parts = request.Split('|');
                            string result = AuthService.Login(parts[1], parts[2]);
                            writer.WriteLine(result);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Server error: {ex.Message}");
            }
            finally 
            {
                client.Close();
            }
        }
    }
}
