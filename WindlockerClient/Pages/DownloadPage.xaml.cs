using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindlockerClient.Pages
{
    /// <summary>
    /// DownloadPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DownloadPage : Page
    {
        public DownloadPage()
        {
            InitializeComponent();
        }

        private void btn_Download_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog o = new SaveFileDialog();
            o.Title = "asdf";
            //string filename = ServerCommunication.GET("http://iwin247.kr:3002/upload/name/" + txtKey.Text, "");
            //o.FileName = filename;
            if (o.ShowDialog() == DialogResult.OK)
            {
                using (var client = new WebClient())
                {
                    //client.DownloadFile("http://iwin247.kr:3002/upload/sync/" + txtKey.Text, filename);
                }
            }
        }
    }
}
