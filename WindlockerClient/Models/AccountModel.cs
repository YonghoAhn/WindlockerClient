using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindlockerClient.Models
{
    class AccountModel
    {
        public static string Token { get; internal set; }
        public static string ID { get; internal set; }
        public static string Nickname { get; internal set; }
        public static Image ProfileImage { get; set; }
    }
}
