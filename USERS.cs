using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using chatFile.Structs.Userlist;

namespace chatFile
{
    public class USERS
    {
        string ip = "";
        string mac = "";
        string nickname = "";
        int count = 0;
        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        TcpClient ctcp;
        Userlist[] uls;

        public USERS()
        {
            uls = new Userlist[1];
        }

        public void addUser(TcpClient ctcp, string ip, string mac, string nickname)
        {
            bool backword = false;
            int count = 0;
            int bcount = 0;
            int end = (uls.Length-1);
            int id = 0;
            Userlist[] temp = uls;
            temp = uls;
            uls = new Userlist[uls.Length];
            uls = temp;
            uls[end].ip = ip;
            uls[end].mac = mac;
            uls[end].nickname = nickname;
            uls[end].date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            uls[end].ctcp = ctcp;
            Random rnd = new Random(5000);
            do{
                id = rnd.Next(end*5000);
                if(count < end){
                    if(id == uls[count].id)
                    {
                        id = rnd.Next(end*5000);
                        count = 0;
                        bcount = 0;
                    }
                    else
                    {
                        count++;
                        bcount++;
                    }
                }
                else
                {
                    if(bcount >= end)
                        backword = true;
                }
            }while(backword == false);
            uls[end].id = id;
        }
        /*
        public void sendMessage(string msg)
        {
            MESSAGE message = new MESSAGE(this.ctcp);
            message.sendMessage(msg);
        }

        public string receiveMessage()
        {
            MESSAGE message = new MESSAGE(this.ctcp);
            string msg = message.receiveMessage();
            return msg;
        }
        */
        public void sendFile()
        {
        }

        public void receiveFile()
        {
        }

        public void transferStatus()
        {
        }
    }
}
