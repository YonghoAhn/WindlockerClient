using Microsoft.Win32;
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

namespace WindlockerClient.Pages
{
    /// <summary>
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void lblSignup_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            // Change the page of the frame.
            if (pageFrame != null)
            {
                pageFrame.Navigate(new SignupPage());
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string l = ServerCommunication.Login(txtID.Text, txtPW.Password);
            if (l != "error")
            {
                RegistryKey key = Registry.CurrentUser;
                key.CreateSubKey("Windlocker");
                key = key.OpenSubKey("Windlocker", true);
                key.SetValue("token", l);
                Session.Token = l;
                Session.ID = txtID.Text;
                MessageBox.Show("Login Success!", "Login", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
