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
using System.Windows.Shapes;

namespace WindlockerClient
{
    /// <summary>
    /// AccountWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();
            frame.Navigate(new Pages.LoginPage());
        }

        private void lblClose_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Handler_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            DragMove();
        }
    }
}
