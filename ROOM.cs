using System;
using System.Collections.Generic;
using System.Text;
using chatFile.Structs.Userlist;
using chatFile.Structs.Room;
using chatFile.Structs.Roomlist;

namespace chatFile
{
    public class ROOM
    {
        int max_room = 0;
        int count = 0;
        Room[] ulr;
        Roomlist[] list;
        Userlist[] uls;

        public ROOM()
        {
            ulr = new Room[1];
        }

        public void addRoom(string name, string pwd, int max_user)
        {
            bool backword = false;
            int count = 0;
            int bcount = 0;
            int end = (uls.Length + 1);
            int id = 0;
            Room[] temp = ulr;
            temp = ulr;
            ulr = new Room[ulr.Length + 1];
            ulr = temp;
            ulr[end].name = name;
            ulr[end].pwd = pwd;
            ulr[end].max_user = max_user;
            Random rnd = new Random(5000);
            do
            {
                id = rnd.Next(end * 5000);
                if (count < end)
                {
                    if (id == uls[count].id)
                    {
                        id = rnd.Next(end * 5000);
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
                    if (bcount >= end)
                        backword = true;
                }
            } while (backword == false);
            ulr[end].id = id;
        }
        /*
        public bool joinRoom(int room, string pwd, USERS user)
        {
            bool backword = false;
            int id = searchRoom(room);
            if (id != -1)
            {
                ulr[id].addUser(user);
                backword = true;
            }
            return backword;
        }
        */
        public bool closeRoom(int room, string pwd, USERS user)
        {
            bool backword = false;
            int id = searchRoom(room);
            if (id != 1)
            {
                ulr[id].status = false;
            }
            return backword;
        }

        public int searchRoom(int room)
        {
            int id=0;
            for (int count = 0; count <= (ulr.Length / 2); count++)
            {
                if (ulr[count].id == room)
                {
                    id = count;
                }
                else
                {
                    id = -1;
                }
            }
            return id;
        }

        public Roomlist[] listRooms(){
            int end = (ulr.Length/2);
            list = new Roomlist[end];
            for(int count = 0; count <= end; count++){
                list[count].id = ulr[count].id;
                list[count].name = ulr[count].name;
                list[count].max_user = ulr[count].max_user;
            }
            return list;
        }
    }
}
