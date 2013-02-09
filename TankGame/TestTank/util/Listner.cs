using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace TestTank
{
    class Listner
    {
       
        TcpListener listner;
        StreamReader sr;
        
        public Listner()
        {
            listner = new TcpListener(7000);
            listner.Start();
         
        }

        public String receiveData() {
        try {
        
                sr = new StreamReader(new NetworkStream(listner.AcceptSocket()));
                 return sr.ReadLine();
            } 
         catch (Exception e) {
            Console.WriteLine("Communication (RECEIVING) Failed! \n " + e.Message);
            return null;
        }
    }
}


    }

