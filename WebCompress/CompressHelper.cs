using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCompress
{
    public class CompressHelper
    {
        public event EventHandler Compressed;
        public event EventHandler EndCompress;

        /// <summary>
        /// 开始压缩
        /// </summary>
        /// <param name="fileFullname">文件名</param>
        /// <param name="fileType">文件类型 js,css,html</param>
        public void StartCompress(string fileFullname, string fileType)
        {
            var args = new CompressArgs
            {
                FileFullname = fileFullname,
                FileType = fileType
            };
            OnCompressed(args);
        }

        private void OnCompressed(EventArgs args)
        {
            var compressed = Compressed;
            if (compressed != null)
            {
                compressed.BeginInvoke(this, args, CompressedCallback, args);
            }
        }

        private void CompressedCallback(IAsyncResult state)
        {
            var args = state.AsyncState as CompressArgs;
            if (args == null) return;
            var endCompress = EndCompress;
            if (endCompress != null)
            {
                endCompress(this, args);
            }
        }
    }

   

    public class CompressArgs : EventArgs
    {
        public string FileType { get; set; }
        public string FileFullname { get; set; }
        public string Data { get; set; }
    }
}
