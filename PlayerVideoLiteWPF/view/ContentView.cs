using PlayerVideoLiteWPF.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PlayerVideoLiteWPF.view
{
    public class ContentView
    {
        //VARIABLES
        public String currentType;
        public Uri lastVideo;
        public Uri lastBg;
        public Grid backgroundGrid;
        public MediaElement videoMedia;

        //CONSTANT
        public const String ONCE = "ONCE";
        public const String LOOP = "LOOP";

        //FUNCTIONS
        public void init(Grid _backgroundGrid, MediaElement _videoMedia)
        {
            backgroundGrid = _backgroundGrid;

            videoMedia = _videoMedia;
            videoMedia.Width = PlayerVideoLiteWPF.Properties.Settings.Default.AppWidth;
            videoMedia.Height = PlayerVideoLiteWPF.Properties.Settings.Default.AppHeight;
        }

        public void setupDefault(Uri _lastBg)
        {
            lastBg = _lastBg;
            addBackground(lastBg);
        }

        //BACKGROUND
        public void addBackground(Uri mediaPath)
        {
            try
            {
                ImageBrush bgBrush = new ImageBrush();
                Image bgImage = new Image();
                bgImage.Source = new BitmapImage(mediaPath);
                bgBrush.ImageSource = bgImage.Source;
                backgroundGrid.Background = bgBrush;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContentView:addBackground] " + ex);
            }
        }

        //VIDEO
        public void addVideo(Uri videoPath)
        {
            try
            {
                backgroundGrid.Background = Brushes.Black;
                videoMedia.Source = videoPath;
                videoMedia.Play();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContentView:addBackground] " + ex);
            }
        }

        public void stopVideo()
        {
            if (videoMedia != null)
            {
                videoMedia.Stop();
                videoMedia.Source = null;
            }
        }

        public void endedVideo()
        {
            if (currentType == LOOP)
            {
                backgroundGrid.Background = Brushes.Black;
                videoMedia.Play();
            }
            else
            {
                if (lastBg != null)
                    addBackground(lastBg);

                if (lastVideo != null)
                    addVideo(lastVideo);
                else
                    stopVideo();
            }
        }

        //SELECT MEDIA
        public void selectMedia(MainModel model , String input)
        {
            Debug.WriteLine("KEY INPUT: " + input);
            for (int i = 0; i < model.mediaList.Count; i++)
            {
                if(input == model.mediaList[i].key)
                {
                    Debug.WriteLine("KEY INPUT: " + input + "==" + model.mediaList[i].key + "_" + model.mediaList[i].id);// + "_" + model.mediaList[i].mediaBgString + "_" + model.mediaList[i].mediaVideoString);

                    if((model.mediaList[i].mediaBgString != null) && (model.mediaList[i].mediaBgString != String.Empty))
                    {
                        addBackground(model.mediaList[i].mediaBg);

                        if (currentType == LOOP)
                        {
                            lastBg = model.mediaList[i].mediaBg;
                            lastVideo = null;
                        }
                            
                    }

                    if ((model.mediaList[i].mediaVideoString != null) && (model.mediaList[i].mediaVideoString != String.Empty))
                    {
                        currentType = model.mediaList[i].type;
                        addVideo(model.mediaList[i].mediaVideo);

                        if (currentType == LOOP)
                            lastVideo = model.mediaList[i].mediaVideo;
                    }
                    else
                    {
                        stopVideo();
                    }
                }  
            }
        }

    }
}
