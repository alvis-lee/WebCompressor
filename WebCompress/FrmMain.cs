using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WebCompressCommon;

namespace WebCompress
{
    public partial class FrmMain : Form
    {
        private CompressHelper _compressHelper = new CompressHelper();
        private List<string> _fileList = new List<string>();
        private int _totalCount;
        private int _completedCount;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _compressHelper.Compressed += StartCompressed;
            _compressHelper.EndCompress+=EndCompressed;
        }

        /// <summary>
        /// 浏览发布目录
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                _fileList.Clear();
                _completedCount = 0;
                _totalCount = 0;
                txtPath.Text = folder.SelectedPath;
                foreach (var file in Directory.GetFiles(folder.SelectedPath, "*.*", SearchOption.AllDirectories).Where(p => p.EndsWith(".js") || p.EndsWith(".css") || p.EndsWith(".html")))
                {
                    #region 测试
                    //for (var i = 0; i < 1000; i++)
                    //{
                    //    if (file.EndsWith(".js"))
                    //    {
                    //        File.Copy(file, string.Format("{0}.js", DateTime.Now.ToString("yyyyMMdddHHmmssfff")));
                    //    }
                    //    else if (file.EndsWith(".css"))
                    //    {
                    //        File.Copy(file, string.Format("{0}.css", DateTime.Now.ToString("yyyyMMdddHHmmssfff")));
                    //    }
                    //    else if (file.EndsWith(".html"))
                    //    {
                    //        File.Copy(file, string.Format("{0}.html", DateTime.Now.ToString("yyyyMMdddHHmmssfff")));
                    //    }
                    //    Thread.Sleep(10);
                    //}
                    #endregion

                    _fileList.Add(file);
                }
                _totalCount = _fileList.Count();
                lblCssCount.Text = string.Format("压缩文件数：{0}", _totalCount);
                pbCompress.Maximum = _totalCount;
            }
        }

        /// <summary>
        /// 压缩
        /// </summary>
        private void btnCompress_Click(object sender, EventArgs e)
        {
            //var file = @"C:\Users\Administrator\Desktop\ALGroup\前端压缩工具\Test\test.html";
            //_compressHelper.StartCompress(file, "html");

            foreach (var file in _fileList)
            {
                if (string.IsNullOrEmpty(file)) continue;
                string fileType = "";
                if (file.EndsWith(".js"))
                {
                    fileType = "js";
                }
                else if (file.EndsWith(".css"))
                {
                    fileType = "css";
                }
                else if (file.EndsWith(".html"))
                {
                    fileType = "html";
                }
                _compressHelper.StartCompress(file, fileType);
            }
        }

        /// <summary>
        /// 压缩事件
        /// </summary>
        private void StartCompressed(object sender, EventArgs e)
        {
            try
            {
                var args = e as CompressArgs;
                if (args == null) return;
                var data = File.ReadAllText(args.FileFullname);
                switch (args.FileType)
                {
                    case "js":
                        args.Data = OschinaCompress.JsCompress(data);
                        break;
                    case "css":
                        args.Data = OschinaCompress.CssCompress(data);
                        break;
                    case "html":
                        args.Data = OschinaCompress.HtmlCompress(data);
                        args.Data = string.IsNullOrEmpty(args.Data) ? args.Data : args.Data.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        break;
                }
            }
            catch (Exception ex)
            { 
            //
            }
        }

        private void EndCompressed(object sender, EventArgs e)
        {
            try
            {
                var args = e as CompressArgs;
                if (args == null) return;
                if (!string.IsNullOrEmpty(args.Data))
                {
                    File.WriteAllText(args.FileFullname, args.Data);
                    _fileList.Remove(args.FileFullname);
                    _completedCount++;
                }
                Invoke(new Action(() =>
                {
                    lblCompletedCount.Text = string.Format("已压缩文件：{0}", _completedCount);
                    pbCompress.Value = _completedCount;
                }));
            }
            catch (Exception ex)
            { 
            //
            }
        }

        #region 测试
        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    var cssString = File.ReadAllText(@"C:\Users\Administrator\Desktop\ALGroup\前端压缩工具\Test\test.css");

        //    var resultCss = CssMinifier.MinifyCss(cssString.Replace('\r',' ').Replace('\r',' '));

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var cssString = File.ReadAllText(@"C:\Users\Administrator\Desktop\ALGroup\前端压缩工具\Test\test.css");

        //   var resultCss = OschinaCompress.CssCompress(cssString);

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    var jsString = File.ReadAllText(@"C:\Users\Administrator\Desktop\ALGroup\前端压缩工具\Test\test.js");

        //    var resultCss = OschinaCompress.CssCompress(jsString);
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    var htmlString = File.ReadAllText(@"C:\Users\Administrator\Desktop\ALGroup\前端压缩工具\Test\test.html");
        //    var resultHtml = OschinaCompress.HtmlCompress(htmlString);
        //    File.WriteAllText(@"C:\Users\Administrator\Desktop\ALGroup\前端压缩工具\Test\test.min.html", resultHtml);
        //}
        #endregion

    }
}
