using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCompressCommon
{
    /// <summary>
    /// CSS压缩
    /// http://cssminifier.com/
    /// </summary>
    public static class CssMinifier
    {
        private const string URL_CSS_MINIFIER = "https://cssminifier.com/raw";
        private const string POST_PAREMETER_NAME = "input";
        
        /// <summary>
        /// 压缩CSS
        /// </summary>
        /// <param name="inputCss">CSS</param>
        /// <returns>压缩后的CSS</returns>
        public static string MinifyCss(string inputCss)
        {
            string resultCss = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL_CSS_MINIFIER);
            request.Method = "POST";
            string formContent = POST_PAREMETER_NAME + "=" + inputCss;
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
                resultCss = reader.ReadToEnd();
                reader.Close();
                str.Close();
            }
            response.Close();
            return resultCss;
        }

        /// <summary>
        /// 异步压缩CSS
        /// </summary>
        /// <param name="inputCss">CSS</param>
        /// <returns>压缩后的CSS</returns>
        public static async Task<String> MinifyCssAsync(string inputCss)
        {
            List<KeyValuePair<String, String>> contentData = new List<KeyValuePair<String, String>>
        {
            new KeyValuePair<String, String>(POST_PAREMETER_NAME, inputCss)
        };

            using (HttpClient httpClient = new HttpClient())
            {
                using (FormUrlEncodedContent content = new FormUrlEncodedContent(contentData))
                {
                    using (HttpResponseMessage response = await httpClient.PostAsync(URL_CSS_MINIFIER, content))
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }
        }
    }
}
