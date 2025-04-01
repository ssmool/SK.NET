using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace chatFile.Structs.Room
{
    public struct Room
    {
        public USERS users;
        public string name;
        public string pwd;
        public int id;
        public int max_user;
        public bool status;
    }
}
namespace chatFile.Structs.Roomlist
{
    public struct Roomlist
    {
        public string name;
        public int id;
        public int max_user;
    }
}

namespace chatFile.Structs.Userlist
{
    public struct Userlist
    {
        public int id ;
        public string ip;
        public string mac;
        public string nickname;
        public DateTime date;
        public TcpClient ctcp;
    }
}