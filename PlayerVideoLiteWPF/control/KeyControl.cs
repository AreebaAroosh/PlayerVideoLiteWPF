using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlayerVideoLiteWPF.control
{
    public class KeyControl
    {
        //VARIABLES
        private MainWindow app; 

        //FUNCTIONS
        public void init(MainWindow _app)
        {
            app = _app;
        }

        //FULLSCREEN VERIFY
        private void checkFullScreen()
        {
            Debug.WriteLine("[KeyControl-checkFullScreen] CHECK FULLSCREEN");

            if (app.WindowState == WindowState.Maximized)
                app.WindowState = WindowState.Normal;
            else
                app.WindowState = WindowState.Maximized;
        }


        //KEY EVENT
        public void checkKeyUp(KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
                checkFullScreen();
        }
    }
}
