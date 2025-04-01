using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace chatFile
{
    public class ClientCommand
    {
        XmlDataDocument data;

        public ClientCommand()
        {
            data = new XmlDataDocument();
            data.LoadXml("data/ClientCommands.xml");
        }
        /*
        public string CommandInterpretation() 
        {
            bool backword = false;
            int count = 0;
            int mnodes = data.ChildNodes.Count;
            do
            {

            } while (!backword);

        }
        */
    }
}
