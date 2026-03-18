using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server
{
    class TcpServer
    {
        //tworzymy nasluch na protokole TCP

        private TcpListener _listener;

        public TcpServer()
        {
            _listener = new TcpListener(IPAddress.Any, 9001);
        }

        public async Task StartASync()
        {
            //uruchomienie nasluchu
            _listener.Start();
            Console.WriteLine("Serwer dziala na porcie 9001...");

            //oczekiwanie na polaczenie

            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                Console.WriteLine("Serwer nasluchuje.. nastapilo polaczenie z klientem...");
                _ = HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            //dwukierunkowe polaczenie po TCP
            using(NetworkStream stream = client.GetStream())
            {
                using (client)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if(bytesRead > 0)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Otrzymana wiadomosc od klienta: {receivedMessage}");

                        string responseMessage = $"Serwer otrzymal wiadomosc poprawnie, która brzmiala: {receivedMessage}";
                        byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                        await stream.WriteAsync(responseData, 0, responseData.Length);
                    }
                }
                client.Close();
            }
        }

        static async Task Main(string[] args)
        {
            TcpServer server = new TcpServer();
            await server.StartASync();
        }
    }
}