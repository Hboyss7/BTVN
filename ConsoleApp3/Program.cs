using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.IO;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket SockServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipadAny = IPAddress.Any;
            IPEndPoint serverEndPoint = new IPEndPoint(ipadAny,6174);

            SockServer.Bind(serverEndPoint);

            SockServer.Listen(10);
            Console.WriteLine("Waiting for client connect...");

            Socket SockClient= SockServer.Accept();
            Console.WriteLine("Client connected");

            EndPoint clientEndPoint = SockClient.RemoteEndPoint;
            Console.WriteLine(clientEndPoint.ToString());

            byte[] buffer;

            while (true)
            {
                string hello = Console.ReadLine();
                if (hello == null)
                {
                    break;
                }
                buffer = Encoding.ASCII.GetBytes(hello);
                SockClient.Send(buffer, 0, buffer.Length, SocketFlags.None);
                buffer = new byte[1024];
            }


            Console.ReadKey();

        }
    }
}
