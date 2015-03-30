using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Security.Cryptography;



namespace ScribeDriver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool locked;
        String lockPassword;

        LayoutProfile profile;
        scribingProcessManager scribeManager;
        Thread scribeThread;

        public MainWindow()
        {

            InitializeComponent();
            profile = new LayoutProfile();
            profile.defaultSettings();
            scribeManager = new scribingProcessManager();

            scribeThread = new Thread(new ThreadStart(scribeManager.run));


            profileDisplay.Text = profile.dataString;
            locked = false;
            lockPassword = "690E2695B6AA8F08DC1FD736072E5819";

            scribeButton.Click += scribeButton_Click;
            lockButton.Click += lockButton_Click;


        }

        void scribeButton_Click(object sender, RoutedEventArgs args)
        {
            if (!scribeThread.IsAlive)
            {
                scribeThread.Start();
            }
            else
            {
                scribeThread.Abort();
                scribeThread = new Thread(new ThreadStart(scribeManager.run));

            }
           


        }

        void lockButton_Click(object sender, RoutedEventArgs args)
        {


            if (!locked)
            {
                dataDisplay.Visibility = Visibility.Collapsed;
                templateButton.Visibility = Visibility.Collapsed;
                dataGrid.Visibility = Visibility.Collapsed;
                scribeButton.Visibility = Visibility.Collapsed;
                startingValueInput.Visibility = Visibility.Collapsed;

                password.Visibility = Visibility.Visible;
                lockButton.Content = "Unlock";
                locked = true;


            }
            else if (locked)
            {



                String thisPassword = password.Password;

                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] tmpSource;
                byte[] tmpHash;

                tmpSource = ASCIIEncoding.ASCII.GetBytes(thisPassword); // Turn password into byte array
                tmpHash = md5.ComputeHash(tmpSource);

                StringBuilder sOutput = new StringBuilder(tmpHash.Length);
                for (int i = 0; i < tmpHash.Length; i++)
                {
                    sOutput.Append(tmpHash[i].ToString("X2"));  // X2 formats to hexadecimal
                }

                if (sOutput.ToString() == lockPassword)
                {
                    //change back and unlock
                    dataDisplay.Visibility = Visibility.Visible;
                    templateButton.Visibility = Visibility.Visible;
                    dataGrid.Visibility = Visibility.Visible;
                    scribeButton.Visibility = Visibility.Visible;
                    startingValueInput.Visibility = Visibility.Visible;
                    password.Visibility = Visibility.Collapsed;


                    lockButton.Content = "Lock";
                    locked = false;
                    password.Background = null;
                    password.Password = null;
                }
                else
                {
                    password.Background = Brushes.Red;
                }




            }


        }


        void Scribe(int startNumber, string connectionPort)
        {
           
        }


    }
}
