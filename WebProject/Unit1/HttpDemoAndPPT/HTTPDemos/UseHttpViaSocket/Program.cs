using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace UseHttpViaSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入一个有效的Web主机地址（不要输入http://,仅是主机域名或IP地址)：");
            string host=Console.ReadLine();
            int port = 80;
            Console.WriteLine();
            string result = SocketSendReceive(host, port);
            Console.WriteLine(result);
            Console.ReadKey();

        }
        /// <summary>
        /// 创建Socket
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        private static Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;
            //访问DNS Server，以获取主机的IP地址
            hostEntry = Dns.GetHostEntry(server);
            //依次连接各个IP地址，有一个成功时就退出循环
            foreach (IPAddress address in hostEntry.AddressList)
            {
                //指定IP终结点
                IPEndPoint ipe = new IPEndPoint(address, port);
                //使用TCP协议
                Socket tempSocket =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                //尝试连接
                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }
        /// <summary>
        /// 向Web Server发送HTTP请求，返回Server发回的数据
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        private static string SocketSendReceive(string server, int port)
        {
            //依据HTTP协议规范，构建HTTP请求
            string request = "GET / HTTP/1.1\r\nHost: " + server +
                "\r\nConnection: Close\r\n\r\n";
            byte[] bytesSent = Encoding.UTF8.GetBytes(request);
            byte[] bytesReceived = new byte[1024];

            // 获取一个己连接的socket
            Socket s = ConnectSocket(server, port);

            if (s == null)
                return ($"无法连接主机{server}:{port}");

            // 发送HTTP请求
            s.Send(bytesSent, bytesSent.Length, 0);

            int bytes = 0;
            var mem = new MemoryStream();//用于缓存数据

            do
            {
                bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                mem.Write(bytesReceived, 0, bytes);
            }
            while (bytes > 0);//循环接收数据

            //返回服务端发回的所有数据（转换为UTF8编码的字符串)
            return Encoding.UTF8.GetString(mem.ToArray());
        }


    }
}
