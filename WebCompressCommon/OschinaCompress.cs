using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebCompressCommon
{
    /// <summary>
    /// 前端压缩
    /// http://tool.oschina.net/jscompress
    /// </summary>
    public static class OschinaCompress
    {
        /// <summary>
        /// 压缩css
        /// </summary>
        /// <param name="rawCss">需要压缩的css</param>
        /// <returns>压缩后的css</returns>
        public static string CssCompress(string rawCss)
        {
            string cssJson = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://tool.oschina.net/action/jscompress/css_compress?linebreakpos=0");
            request.Method = "POST";
            string formContent = rawCss;
            byte[] byteArray = Encoding.UTF8.GetBytes(formContent);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream str = request.GetRequestStream();
            str.Write(byteArray, 0, byteArray.Length);
            str.Close();

            WebResponse response = request.GetResponse();
            str = response.GetResponseStream();
            if (str != null)
            {
                StreamReader reader = new StreamReader(str);
                cssJson = reader.ReadToEnd();
                reader.Close();
                str.Close();
            }
            response.Close();
            var dic = JsonConverter.JsonToDictionary(cssJson);
            return dic["result"].ToString();
        }

        /// <summary>
        /// 压缩js
        /// </summary>
        /// <param name="rawJs">需要压缩的js</param>
        /// <returns>压缩后的js</returns>
        public static string JsCompress(string rawJs)
        {
            string cssJson = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://tool.oschina.net/action/jscompress/js_compress?munge=0&linebreakpos=0");
            request.Method = "POST";
            string formContent = rawJs;
            byte[] byteArray = Encoding.UTF8.GetBytes(formContent);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream str = request.GetRequestStream();
            str.Write(byteArray, 0, byteArray.Length);
            str.Close();

            WebResponse response = request.GetResponse();
            str = response.GetResponseStream();
            if (str != null)
            {
                StreamReader reader = new StreamReader(str);
                cssJson = reader.ReadToEnd();
                reader.Close();
                str.Close();
            }
            response.Close();
            var dic = JsonConverter.JsonToDictionary(cssJson);
            return dic["result"].ToString();
        }

        /// <summary>
        /// 压缩html
        /// </summary>
        /// <param name="rawHtml">需要压缩的html</param>
        /// <returns>压缩后的html</returns>
        public static string HtmlCompress(string rawHtml)
        {
            string cssJson = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://tool.lu/html/ajax.html");
            request.Method = "POST";
            string formContent = string.Format("code={0}&operate=compress", rawHtml);
            byte[] byteArray = Encoding.UTF8.GetBytes(formContent);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream str = request.GetRequestStream();
            str.Write(byteArray, 0, byteArray.Length);
            str.Close();

            WebResponse response = request.GetResponse();
            str = response.GetResponseStream();
            if (str != null)
            {
                StreamReader reader = new StreamReader(str);
                cssJson = reader.ReadToEnd();
                reader.Close();
                str.Close();
            }
            response.Close();
            var dic = JsonConverter.JsonToDictionary(cssJson);
            return dic["text"].ToString();
        }
    }
}
