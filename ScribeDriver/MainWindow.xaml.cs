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

namespace ScribeDriver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool locked;
        public MainWindow()
        {

            InitializeComponent();
            LayoutProfile profile = new LayoutProfile();
            profile.defaultSettings();
            locked = false;

            scribeButton.Click += scribeButton_Click;
            lockButton.Click += lockButton_Click;

            
            

            


        }

        void scribeButton_Click(object sender, RoutedEventArgs args)
        {
            profileDisplay.Text = "Scribing Button Clicked";
        }

        void lockButton_Click(object sender, RoutedEventArgs args)
        {
            profileDisplay.Text = "lock Button Clicked";
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

                //TODO: Password Verification Code


                dataDisplay.Visibility = Visibility.Visible;
                templateButton.Visibility = Visibility.Visible;
                dataGrid.Visibility = Visibility.Visible;
                scribeButton.Visibility = Visibility.Visible;
                startingValueInput.Visibility = Visibility.Visible;

                password.Visibility = Visibility.Collapsed;
                lockButton.Content = "lock";
                locked = false;

            }


        }
    }
}
