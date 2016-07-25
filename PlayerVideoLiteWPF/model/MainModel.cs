using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace PlayerVideoLiteWPF.model
{
    public class MainModel
    {
        //VARIABLES
        public Uri mediaBg;
        public String defaultID;
        public int numMedia;
        public List<MediaModel> mediaList = new List<MediaModel>();

        //FUNCTIONS
        public void setupModel(XmlDocument xmlDoc)
        {
            //defaut background
            if((xmlDoc.DocumentElement.Attributes["defaultBG"].Value != null) && (xmlDoc.DocumentElement.Attributes["defaultBG"].Value != String.Empty))
                mediaBg = new Uri(AppDomain.CurrentDomain.BaseDirectory + PlayerVideoLiteWPF.Properties.Settings.Default.ResourceName + "/" + xmlDoc.DocumentElement.Attributes["defaultBG"].Value);

            //defaut ID
            defaultID = xmlDoc.DocumentElement.Attributes["defaultID"].Value;

            //number of videos
            numMedia = xmlDoc.GetElementsByTagName("media").Count;

            //get video
            foreach (XmlNode xmlNode in xmlDoc.GetElementsByTagName("media"))
            {
                MediaModel mediaModel = new MediaModel();
                mediaModel.setupModel(xmlNode);
                mediaList.Add(mediaModel);
            }
        }

        public MediaModel getMediaById(String id)
        {
            foreach (MediaModel mediaModel in mediaList)
            {
                if (id == mediaModel.id)
                {
                    return mediaModel;
                }
            }

            return null;
        }
    }
}
