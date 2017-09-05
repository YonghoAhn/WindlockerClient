using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindlockerClient
{
    class ServerCommunication
    {
        private static readonly string SERVER_URL = "http://iwin247.kr:3002";
        public static string GET(string URL, string Content)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL + Content);
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.StatusCode);
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            }
            catch (WebException we)
            {
                //Console.WriteLine(((HttpWebResponse)we.Response).StatusCode);
                return "";
            }
        }

        public static string POST_FILE(string URL, string Filename)
        {
            try
            {
                FileStream stream = File.Open(Filename, FileMode.Open);
                StreamContent scontent = new StreamContent(stream);
                scontent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                {
                    FileName = Filename,
                    Name = "file"
                };
                scontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                var client = new HttpClient();
                var multi = new MultipartFormDataContent();
                multi.Add(scontent);
                client.BaseAddress = new Uri("http://iwin247.kr:3002/");
                var result = client.PostAsync("upload/", multi).Result;
                Console.WriteLine(result.ReasonPhrase);
                return result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return "error";
            }

        }

        public static string POST(string URL, string Content)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            var postData = Content;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Method = "POST";
            var data = Encoding.ASCII.GetBytes(postData);
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            }
            catch (WebException we)
            {
                //Console.WriteLine(((HttpWebResponse)we.Response).StatusCode);
                return "";
            }
        }

        public static string POST_JSON(string URL, string Content)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            var postData = Content;
            request.ContentType = "application/json";
            request.ContentLength = postData.Length;
            request.Method = "POST";
            var data = Encoding.ASCII.GetBytes(postData);
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            }
            catch (WebException we)
            {
                //Console.WriteLine(((HttpWebResponse)we.Response).StatusCode);
                return "";
            }
        }


        public static bool Signup(string id, string pw, string name)
        {
            string post = POST(SERVER_URL + "/auth/signup", "id=" + id + "&passwd=" + pw + "&name=" + name);
            if (post != "")
            {
                JObject j = JObject.Parse(post);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Login(string id, string pw, bool isHashed = false)
        {
            SHA256Managed sHA256Managed = new SHA256Managed();
            string post = "";
            if (!isHashed)
            {
                string password = Convert.ToBase64String(sHA256Managed.ComputeHash(Encoding.UTF8.GetBytes(pw)));
                post = POST(SERVER_URL + "/auth/signin", "id=" + id + "&passwd=" + password);
            }
            else
            {
                post = POST(SERVER_URL + "/auth/signin", "id=" + id + "&passwd=" + pw);
            }
            
            if (post != "")
            {
                JObject j = JObject.Parse(post);
                JToken jt = j["token"];
                return jt.ToString();
            }
            else
            {
                return "error";
            }
        }

        public static bool Auto(string token)
        {
            string get = GET(SERVER_URL, "/auth/auto/" + token);
            if (get != "")
                return true;
            else
                return false;
        }

        public static bool IsLock(string token)
        {
            string get = GET(SERVER_URL, "/lock/" + token);
            if (get != "")
                return true;
            else
                return false;
        }
    }
}
