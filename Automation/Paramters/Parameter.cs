using System;
using System.IO;
using System.Xml;

namespace Automation.Paramters
{
    public class Parameter
    {
        public void CollectParamter()
        {
            string file = "Parameter_Global.xml";

            string path = Environment.CurrentDirectory;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);
        }
    }
}
