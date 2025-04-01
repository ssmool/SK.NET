using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace chatFile
{
    public class CLIENT
    {
        //Structure Data
        string id = "";
        string user = "";
        string pwd = "";
        string nickname = "";
        string host = "";
        int port = 0;
        //Structure Object
        Socket sk;
        MESSAGE message;

        public CLIENT(string user, string pwd, string nickname, string host, int port)
        {
            this.user = user;
            this.pwd = pwd;
            this.nickname = nickname;
            this.host = host;
            this.port = port;
        }

        public bool connect(){
            bool backword = false;
            sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.sk.Connect(this.host, this.port);
            if (authUser())
            {
                backword = true;
            }
            else
            {
                disconect();
                backword = false;
            }
            return backword;
        }

        protected bool authUser()
        {
            bool backword = false;
            string msg = "";
            if (this.sk.Connected)
            {
                msg = receiveMessage();
                if (msg == "returnauth")
                {
                    msg = "u=" + this.user + "&p=" + this.pwd;
                    sendMessage(msg);
                    msg = receiveMessage();
                    if (msg == "Conectado")
                    {
                        backword = true;
                        //msg = receiveMessage();
                    }
                    else
                    {
                        disconect();
                        backword = false;
                    }
                }
            }
            else
            {
                backword = false;
            }
            return backword;
        }

        public bool disconect(){
            bool backword = false;
            sk.Disconnect(false);
            if(!sk.Connected){
                backword = true;
            }else{
                backword = false;
            }
            return backword;
        }

        public bool connected(){
            bool backword = false;
            if (sk.Connected)
            {
                backword = true;
            }
            return backword;
        }
    
        public void sendMessage(string msg)
        {
            message = new MESSAGE(this.sk);
            message.sendMessage(msg);
        }

        public string receiveMessage()
        {
            message = new MESSAGE(this.sk);
            string msg = message.receiveMessage();
            return msg;
        }

        public void sendFile()
        {
        }

        public void receiveFile()
        {
        }

        public void transferStatus()
        {
        }

        public void setIdentity(string identity)
        {
            this.id = identity;
        }

        public string getIdentity()
        {
            return this.id;
        }
    }
}
