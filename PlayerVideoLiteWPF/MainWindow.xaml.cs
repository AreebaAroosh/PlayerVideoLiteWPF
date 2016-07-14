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

namespace PlayerVideoLiteWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //VARIABLES
        private XMLResourceControl xmlResourceControl;
        private KeyControl keyControl;
        
        //FUNCTIONS
        public MainWindow()
        {
            InitializeComponent();
        }

        private void init()
        {
            //xml resource control
            xmlResourceControl = new XMLResourceControl();
            xmlResourceControl.init();

            //keyboard event control
            keyControl = new KeyControl();
            keyControl.init(this);

            //set settings resolution
            setResolution();
        }

        //RESOLUTION
        private void setResolution()
        {
            MainView.Width = PlayerVideoLiteWPF.Properties.Settings.Default.AppWidth;
            MainView.Height = PlayerVideoLiteWPF.Properties.Settings.Default.AppHeight;

            if(PlayerVideoLiteWPF.Properties.Settings.Default.AppFullscreen)
                MainView.WindowState = WindowState.Maximized;
        }


        //EVENTS
        private void MainView_Initialized(object sender, EventArgs e)
        {
            init();
        }

        private void MainView_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyControl != null)
                keyControl.checkKeyUp(e);
        }
    }
}
