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
        /// <summary>
        /// 发布压缩事件
        /// </summary>
        public event EventHandler Compressed;
        /// <summary>
        /// 发布压缩完成事件
        /// </summary>
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

        /// <summary>
        /// 触发压缩事件
        /// </summary>
        private void OnCompressed(EventArgs args)
        {
            var compressed = Compressed;
            if (compressed != null)
            {
                compressed.BeginInvoke(this, args, CompressedCallback, args);
            }
        }

        /// <summary>
        /// 完成压缩回调
        /// </summary>
        private void CompressedCallback(IAsyncResult state)
        {
            var args = state.AsyncState as CompressArgs;
            if (args == null) return;
            try
            {
                Compressed.EndInvoke(state);
                var endCompress = EndCompress;
                if (endCompress != null)
                {
                    //触发压缩完成事件
                    endCompress(this, args);
                }
            }
            catch (Exception ex)
            {
                //
                Console.WriteLine(ex.Message);
            }
        }
    }


    public class CompressArgs : EventArgs
    {
        /// <summary>
        /// 文件类型 css,js,html
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 文件全名
        /// </summary>
        public string FileFullname { get; set; }
        /// <summary>
        /// 压缩后的数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 压缩是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}
