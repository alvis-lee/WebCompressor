using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

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
        /// http://tool.oschina.net/action/jscompress/css_compress?linebreakpos=0
        /// </summary>
        /// <param name="rawCss">需要压缩的css</param>
        /// <returns>压缩后的css</returns>
        public static string CssCompress(string rawCss)
        {
            var urlString = @"http://tool.oschina.net/action/jscompress/css_compress?linebreakpos=0";
            var param = rawCss;
            string responseData = RequestDataByPost(urlString, param);
            var dic = JsonConverter.JsonToDictionary(responseData);
            if (dic.ContainsKey("result"))
                return dic["result"].ToString();
            return string.Empty;
        }

        /// <summary>
        /// 压缩css
        /// http://tool.lu/css/ajax.html
        /// </summary>
        /// <param name="rawCss">需要压缩的css</param>
        /// <returns>压缩后的css</returns>
        public static string CssCompress2(string rawData)
        {
            var urlString = @"http://tool.lu/css/ajax.html";
            var param = string.Format("code={0}&operate=purify", HttpUtility.UrlEncode(rawData));
            string responseData = RequestDataByPost(urlString, param);
            var dic = JsonConverter.JsonToDictionary(responseData);
            if (dic.ContainsKey("text"))
                return dic["text"].ToString();
            return string.Empty;
        }

        /// <summary>
        /// 压缩js
        /// http://tool.oschina.net/action/jscompress/js_compress?munge=0&linebreakpos=0
        /// </summary>
        /// <param name="rawJs">需要压缩的js</param>
        /// <returns>压缩后的js</returns>
        public static string JsCompress(string rawJs)
        {
            var urlString = @"http://tool.oschina.net/action/jscompress/js_compress?munge=0&linebreakpos=0";
            var param = rawJs;
            string responseData = RequestDataByPost(urlString, param);
            var dic = JsonConverter.JsonToDictionary(responseData);
            if (dic.ContainsKey("result"))
                return dic["result"].ToString();
            return string.Empty;
        }

        /// <summary>
        /// 压缩js
        /// http://tool.lu/js/ajax.html
        /// </summary>
        public static string JsCompress2(string rawData)
        {
            var urlString = @"http://tool.lu/js/ajax.html";
            var param = string.Format("code={0}&operate=purify", HttpUtility.UrlEncode(rawData));
            string responseData = RequestDataByPost(urlString, param);
            var dic = JsonConverter.JsonToDictionary(responseData);
            if (dic.ContainsKey("text"))
                return dic["text"].ToString();
            return string.Empty;
        }

        /// <summary>
        /// 压缩html
        /// </summary>
        /// <param name="rawHtml">需要压缩的html</param>
        /// <returns>压缩后的html</returns>
        public static string HtmlCompress(string rawData)
        {
            var urlString = @"http://tool.lu/html/ajax.html";
            var param = string.Format("code={0}&operate=compress", HttpUtility.UrlEncode(rawData));
            string responseData = RequestDataByPost(urlString, param);
            var dic = JsonConverter.JsonToDictionary(responseData);
            if (dic.ContainsKey("text"))
                return dic["text"].ToString();
            return string.Empty;
        }

        /// <summary>
        /// 向指定服务器请求数据
        /// POST
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        private static string RequestDataByPost(string url, string param)
        {
            string getData = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(param);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream str = request.GetRequestStream();
            str.Write(byteArray, 0, byteArray.Length);
            str.Close();

            //WebResponse response = request.GetResponse();
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response;
            }
            if (response == null) return null;
            str = response.GetResponseStream();
            if (str != null)
            {
                StreamReader reader = new StreamReader(str);
                getData = reader.ReadToEnd();
                reader.Close();
                str.Close();
            }
            response.Close();
            return getData;
        }
    }
}
