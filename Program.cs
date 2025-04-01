using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace chatFile
{
    class Program
    {
        public static void Main(string[] args)
        {
            string user = "";
            string pwd = "";
            string nickname = "";
            string server = "";
            int port = 0;
            string text = "";
            Console.WriteLine("Bem vindo ao Aloha!");
            Console.WriteLine("Servidor:");
            text = Console.ReadLine();
            server = text;
            Console.WriteLine("Porta:");
            text = Console.ReadLine();
            Int32.TryParse(text, out port);
            Console.WriteLine("Nickname:");
            text = Console.ReadLine();
            nickname = text;
            Console.WriteLine("Usuario:");
            text = Console.ReadLine();
            user = text;
            Console.WriteLine("Senha:");
            text = Console.ReadLine();
            pwd = text;
            CLIENT c = new CLIENT(user, pwd, nickname, server, port);
            SERVER s = new SERVER("master", "krir", "He-Man", port);
            s.createServer();
            Thread t = new Thread(s.acceptClient);
            t.Start();
            c.connect();
            if (c.connected())
            {
                Console.WriteLine("Cliente conectado");
                do
                {
                    Console.WriteLine(">:");
                    text = Console.ReadLine();
                    c.sendMessage(text);
                    Console.WriteLine(s.receiveMessage());
                    Console.WriteLine(">:");
                    text = Console.ReadLine();
                    s.sendMessage(text);
                    Console.WriteLine(c.receiveMessage());
                } while (text != "quit");
            }
            else
            {
                Console.WriteLine("Não foi possível conectar ao servidor!");
            }
            text = Console.ReadLine();
        }
    }
}
