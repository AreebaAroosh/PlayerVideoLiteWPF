using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlayerVideoLiteWPF.control;
using PlayerVideoLiteWPF.view;
using System.Diagnostics;

namespace PlayerVideoLiteWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //VARIABLES
        private XMLResourceControl xmlResourceControl;
        private ContentView contentView;
        private KeyControl keyControl;

        //FUNCTIONS
        public MainWindow()
        {
            InitializeComponent();
        }

        private void init()
        {
            //set settings resolution
            setResolution();

            //xml resource control
            xmlResourceControl = new XMLResourceControl();
            xmlResourceControl.init();

            //content view
            contentView = new ContentView();
            contentView.init(MainGrid, videoMedia);

            //keyboard event control
            keyControl = new KeyControl();
            keyControl.init(this);
        }

        //RESOLUTION
        private void setResolution()
        {
            MainView.Width = MainGrid.Width = PlayerVideoLiteWPF.Properties.Settings.Default.AppWidth;
            MainView.Height = MainGrid.Height = PlayerVideoLiteWPF.Properties.Settings.Default.AppHeight;

            if(PlayerVideoLiteWPF.Properties.Settings.Default.AppFullscreen)
                MainView.WindowState = WindowState.Maximized;
        }

        //DEFAULT VALUE
        public void setupDefaultState()
        {
            if(xmlResourceControl.Model != null)
            {
                if (xmlResourceControl.Model.mediaBg != null)
                {
                    Debug.WriteLine("DEFAULT BG: " + xmlResourceControl.Model.mediaBg);
                    Debug.WriteLine("DEFAULT ID: " + xmlResourceControl.Model.defaultID);
                    contentView.setupDefault(xmlResourceControl.Model.mediaBg);
                }   
            }
        }

        //SELECT MEDIA
        public void selectMedia(String key)
        {
            contentView.selectMedia(xmlResourceControl.Model, key);
        }

        private void mediaPlayerView_MediaOpened(object sender, RoutedEventArgs e)
        {

        }

        private void mediaPlayerView_MediaEnded(object sender, RoutedEventArgs e)
        {
            contentView.endedVideo();
        }

        private void mediaPlayerView_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        //EVENTS
        private void MainView_Initialized(object sender, EventArgs e)
        {
            init();
            setupDefaultState();
        }

        private void MainView_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyControl != null)
                keyControl.checkKeyUp(e);
        }
    }
}
