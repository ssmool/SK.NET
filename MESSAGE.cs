using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace chatFile
{
    public class MESSAGE
    {
        NetworkStream ns;

        public MESSAGE(Socket sk)
        {
            this.ns = new NetworkStream(sk);
            
        }

        public MESSAGE(NetworkStream ns)
        {
            this.ns = ns;
        }

        //Process Actions
        public void sendMessage(string message)
        {
            byte[] b = new byte[256];
            b = System.Text.Encoding.ASCII.GetBytes(message);
            ns.Write(b, 0, b.Length);
        }

        public string receiveMessage()
        {
            string message = "";
            int i = 0;
            byte[] b = new byte[256];
            i = ns.Read(b, 0, b.Length);
            message += System.Text.Encoding.ASCII.GetString(b, 0 , i);
            return message;
        }
    }
}
