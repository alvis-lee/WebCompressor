using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using System.Collections;

namespace WebCompressCommon
{
    public class JsonConverter
    {
        /// <summary>
        /// Json转为Dictionary
        /// </summary>
        /// <param name="jsonString">json</param>
        /// <returns>转换后的Dictionary</returns>
        public static Dictionary<string,object> JsonToDictionary(string jsonString)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();

            //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
            return jss.Deserialize<Dictionary<string, object>>(jsonString);
        }
    }
    
   
}