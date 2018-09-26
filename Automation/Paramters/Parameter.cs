using System.IO;
using System.Xml;

namespace Automation.Paramters
{
    public class Parameter
    {
        public void CollectParamter()
        {
            string file = "Parameter_Global.xml";

            // p = Path.GetDirectoryName(Application.ExecutablePath);
            string directory = Directory.GetCurrentDirectory();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);
        }
    }
}
