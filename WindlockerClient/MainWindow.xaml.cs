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
using WindlockerClient.Models;
using WindlockerClient.Pages;

namespace WindlockerClient
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void lblClose_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void FrameHandler_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblClose_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void FrameHandler_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnNickname_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new DownloadPage());
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow();
            settingWindow.ShowDialog();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
