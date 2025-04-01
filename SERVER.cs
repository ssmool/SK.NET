using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace chatFile
{
    public class SERVER
    {
        //Structure Data
        string user = "";
        string pwd = "";
        string nickname = "";
        string ip = "";
        string mac = "";
        int port = 0;
        //Structure Object
        AddressFamily ad;
        TcpClient ctcp;
        TcpListener ltcp;
        NetworkStream ns;
        USERS users;

        public SERVER(string user, string pwd, string nickname, int port)
        {
            this.user = user;
            this.pwd = pwd;
            this.nickname = nickname;
            this.port = port;
            users = new USERS();
        }

        //Natural Actions
        public void createServer()
        {
            ltcp = new TcpListener(System.Net.IPAddress.Any, this.port);
            ltcp.Start(5);
        }

        public void acceptClient()
        {
            ctcp = ltcp.AcceptTcpClient();
            ns = ctcp.GetStream();
           if (authUser())
            {
               ip = IPAddress.Parse(((IPEndPoint)ctcp.Client.LocalEndPoint).Address.ToString()).ToString();
               //mac = PhysicalAddress.Parse(((IPEndPoint)ctcp.Client.LocalEndPoint).Address).ToString();
               
               users.addUser(ctcp, ip, mac, this.nickname);
            }
            else
            {
                disconectClient();
            }
        }

        public bool authUser()
        {
            bool backword = false;
            string msg = "";
            sendMessage("returnauth");
            msg = receiveMessage();
            if (msg == "u=krar&p=rir")
            {
                backword = true;
                sendMessage("Conectado");
                //sendMessage(this.user + " acaba de se conectar");
            }
            else
            {
                sendMessage("Desconectado");
                backword = false;
            }
            return backword;
        }

        //Process Actions
        public void sendMessage(string msg)
        {
            MESSAGE message = new MESSAGE(ns);
            message.sendMessage(msg);
        }

        public string receiveMessage()
        {
            MESSAGE message = new MESSAGE(ns);
            string msg = message.receiveMessage();
            return msg;
        }
        /*
        public Object clientCommand(string msg){
            Object o = new Object();
            if(msg == "listroom"){
                ROOM r = new ROOM();
                Structs.Roomlist.roomlist rl = r.listRooms();
                o = rl;
            }
            else if(msg == "createroom"){
                ROOM r = new ROOM();
                r.createRoom("new", "pwd", 5);
            }
            else if(msg == "joinroom"){
                ROOM r = new ROOM();
                //r.joinRoom(0, "pwd", 
            }
            return o;
        }*/

        public void stop()
        {
        }

        public void disconectClient()
        {
            ltcp.Stop();
        }
    }
}
