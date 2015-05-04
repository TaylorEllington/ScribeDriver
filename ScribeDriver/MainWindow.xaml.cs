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
using System.ComponentModel;
using System.Globalization;



namespace ScribeDriver
{
  
    public partial class MainWindow : Window
    {
        //control variables
        bool locked;
        String lockPassword;

        //functional classes
        LayoutProfile profile;
        scribingProcessManager scribeManager = new scribingProcessManager();
        incrementalCounter counter;
        
        //scribing job details
        int startingValue;
        int startingLocation;
        int maxLocation;

        
    
        //async  thread for scribing
        BackgroundWorker scribeProcess;

        public MainWindow()
        {

            InitializeComponent();
            profile = new LayoutProfile();
            profile.defaultSettings();

            maxLocation = profile.hCount * profile.vCount;
            TotalTextBox.Text = maxLocation.ToString();
            CurrentTextBox.Text = "1";
            startingValueInput.Text = "000";
           
            locked = false;
            lockPassword = "690E2695B6AA8F08DC1FD736072E5819";

            scribeButton.Click += scribeButton_Click;
            lockButton.Click += lockButton_Click;

            scribeProcess = new BackgroundWorker();
            scribeProcess.WorkerReportsProgress = true;
            scribeProcess.WorkerSupportsCancellation = true;
            scribeProcess.DoWork += new DoWorkEventHandler(bw_DoWork);
            scribeProcess.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            scribeProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            counter = new incrementalCounter();


        }



        //Click events
        void scribeButton_Click(object sender, RoutedEventArgs args)
        {
            if (!scribeProcess.IsBusy && validate())
            {
                startingValue = int.Parse(startingValueInput.Text, NumberStyles.HexNumber);
                scribeProcess.RunWorkerAsync();
                scribeButton.Content = "Cancel";
                
            }
            else
            {
                scribeProcess.CancelAsync();

            }
           


        }

        void lockButton_Click(object sender, RoutedEventArgs args)
        {


            if (!locked)
            {
                
                startinValueLabel.Visibility = Visibility.Collapsed;
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
               
                    startinValueLabel.Visibility = Visibility.Visible;
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

        //functions called by click events
        bool OnlyHexInString(string test)
        {
            
            bool check = Int32.TryParse(test, NumberStyles.HexNumber, new CultureInfo("en-US"), out startingValue );
            Debug.WriteLine(startingValue);
            return check;

        }

        bool validate()
        {
            bool isGood  = true;

            string starting = startingValueInput.Text;

            int min = 0;
            int max = 3;
            int tempInt;

            string errorString = "";
            

            if (int.TryParse(CurrentTextBox.Text, NumberStyles.Integer, new CultureInfo("en-US"),  out tempInt) && tempInt < 1 && tempInt > maxLocation)
            {
                errorString += "Please indicate a progress point between the minimum (0) and the maximum (" + maxLocation +")";
                isGood = false;
            }


            if ( !OnlyHexInString(starting) || (starting.Length > max) || (starting.Length < min) )
            {
                errorString += " The Starting Value field contains an improperly formated number. Please enter a valid 3 digit hexadaceimal number (000 - FFF) \n";

                isGood = false;
            }



            Debug.WriteLine(starting.Length);

            if(!isGood){
                MessageBox.Show(errorString);
            }
            else
            {
                startingLocation = tempInt;   
            }
            return isGood;
        }



        //Background worker functions
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            

            counter.seedCounter(startingValue +(startingLocation  -1));
            

            for (int i = (startingLocation-1); i < maxLocation && !worker.CancellationPending; i++)
            {
                worker.ReportProgress(i+1);
                Debug.Write(counter.getValueAsHexString());
               

                scribeManager.setPlunge(plunge(i));
                scribeManager.chipAndDigitSet(xDistance(i), yDistance(i, 0));
                Thread.Sleep(400);
                scribeManager.scribe(counter.getValueAsHexString()[0]);
                Debug.Write("---" + counter.getValueAsHexString()[0]);

                scribeManager.chipAndDigitSet(xDistance(i), yDistance(i, 1));
                Thread.Sleep(400);
                scribeManager.scribe(counter.getValueAsHexString()[1]);
                Debug.Write("---" + counter.getValueAsHexString()[1]);

                scribeManager.chipAndDigitSet(xDistance(i), yDistance(i, 2));
                Thread.Sleep(400);
                scribeManager.scribe(counter.getValueAsHexString()[2]);
                Debug.WriteLine("---" + counter.getValueAsHexString()[2]);
                
                Thread.Sleep(1000);
                counter.next();
            }


            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
           
            }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CurrentTextBox.Text = e.ProgressPercentage.ToString();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if( e.Error == null && !e.Cancelled ){
                CurrentTextBox.Text = "0";
               
            }
            scribeButton.Content = "Scribe";
            MessageBox.Show("Done!");
            scribeManager.finish();
        }

        double yDistance(int ChipNumber, int digit){
            int chipInRow = (ChipNumber % 9) ;

            return profile.yStarts[ChipNumber] - (digit * (0.05));
            
        }
        double xDistance(int ChipNumber){
            
            return profile.xStarts[ChipNumber];
        }

        double plunge(int chipNumber)
        {
            return profile.plunge[chipNumber];
        }
       
        


    }
}
