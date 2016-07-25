using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace PlayerVideoLiteWPF.model
{
    public class MediaModel
    {
        //VARIABLES
        public String id;
        public String key;
        public String type;
        public String mediaBgString;
        public Uri mediaBg;
        public String mediaVideoString;
        public Uri mediaVideo;

        //FUNCTIONS
        public void setupModel(XmlNode xmlNode)
        {
            id = xmlNode.Attributes["ID"].Value.ToString();
            key = xmlNode.Attributes["KEY"].Value.ToString();
            type = xmlNode.Attributes["TYPE"].Value.ToString();

            mediaBgString = xmlNode.Attributes["BG"].Value;
            mediaBg = new Uri (AppDomain.CurrentDomain.BaseDirectory + PlayerVideoLiteWPF.Properties.Settings.Default.ResourceName + "/" + xmlNode.Attributes["BG"].Value);
            mediaVideoString = xmlNode.Attributes["VIDEO"].Value;
            mediaVideo = new Uri(AppDomain.CurrentDomain.BaseDirectory + PlayerVideoLiteWPF.Properties.Settings.Default.ResourceName + "/" + xmlNode.Attributes["VIDEO"].Value);
        }

    }
}
