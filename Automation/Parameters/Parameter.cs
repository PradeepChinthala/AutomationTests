using System;
using System.IO;
using System.Xml;

namespace Automation.Paramters
{
    public class Parameter
    {
        public void CollectParamter(params string[] readCollection)
        {
            string filePath = string.Empty;
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Parameters\");
            if (readCollection.Length == 0)
            {
                filePath = directory+ "Parameter_Global.xml";
            }
            
            string path = Environment.CurrentDirectory;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
        }
    }
}
