using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace TestTank
{
    class Writer
    {
        TcpClient client;
        StreamWriter sw;

        public void sendData(String str)
        {
            try
            {
                client = new TcpClient("localhost", 6000);
                sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                sw.Write(str);
                sw.Close();
            }
            catch(Exception e)
            {
               Console.WriteLine("Communication (WRITING) Error: " +e.Message);
            }
        }

    }
}
