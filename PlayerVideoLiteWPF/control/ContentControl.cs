using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlayerVideoLiteWPF.control
{
    public class XMLResourceControl
    {
        //VARIABLES
        private String folderPath;
        private String fileFullPath;
        private XmlDocument xmlDoc;

        //FUNCTIONS
        public void init()
        {
            //setup path
            folderPath = AppDomain.CurrentDomain.BaseDirectory + PlayerVideoLiteWPF.Properties.Settings.Default.ResourceName;
            fileFullPath = folderPath + PlayerVideoLiteWPF.Properties.Settings.Default.XMLFilename;
            Debug.WriteLine("FILE PATH: " + fileFullPath);

            if (!Directory.Exists(folderPath))
            {
                createMissingFolder();
            }

            if (!File.Exists(fileFullPath))
            {
                createMissingFile();
            }

            loadXmlFile();
        }
       
        private void loadXmlFile()
        {
            //setup xmlDocument
            xmlDoc = new XmlDocument();
            xmlDoc.Load(fileFullPath);

            
        }


        //CREATE MISSING FILES
        private void createMissingFolder()
        {
            Directory.CreateDirectory(folderPath);
        }

        private void createMissingFile()
        {
            //create config.xml
            XmlDocument doc = new XmlDocument();

            //the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //config element
            XmlElement configElement = doc.CreateElement(string.Empty, "Config", string.Empty);
            doc.AppendChild(configElement);

            //media element
            XmlElement mediaElement = doc.CreateElement(string.Empty, "Media", string.Empty);
            configElement.AppendChild(mediaElement);

            doc.Save(fileFullPath);
        }
    }
}
