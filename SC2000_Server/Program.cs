using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SC2000_Server
{
    class Program
    {
        static void Main(string[] args)
        {
             TcpListener server = new TcpListener(IPAddress.Any, 9999);  
           // we set our IP address as server's address, and we also set the port: 9999
            Console.Write(IPAddress.Any);
            server.Start();  // this will start the server
            int i = 0;
            while (true)   //we wait for a connection
            {
                
                TcpClient client = server.AcceptTcpClient();  //if a connection exists, the server will accept it

                NetworkStream ns = client.GetStream(); //networkstream is used to send/receive messages

                byte[] hello = new byte[100];   //any message must be serialized (converted to byte array)
                hello = Encoding.Default.GetBytes(i.ToString());  //conversion string => byte array

                ns.Write(hello, 0, hello.Length);     //sending the message
                i += 1;
                Thread.Sleep(2000);


        }
    }
}

}
