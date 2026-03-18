using System;
using System.Net;
using System.Net.Sockets;

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
        }
    }
}