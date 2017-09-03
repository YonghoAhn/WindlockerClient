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
    /// SignupPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignupPage : Page
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
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
                pageFrame.Navigate(new LoginPage());
            }
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            if (ServerCommunication.Signup(txtID.Text, txtPW.Password, txtName.Text))
            {
                MessageBox.Show("Signup Success!", "Signup", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Signup Error!", "Signup", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
