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
using System.Web.UI;
using System.Windows.Forms;
using WebCompressCommon;

namespace WebCompress
{
    public partial class FrmMain : Form
    {
        private CompressHelper _compressHelper = new CompressHelper();
        private List<string> _fileList = new List<string>(); //压缩文件集合
        private int _totalCount; //压缩文件总数
        private int _completedCount; //成功压缩文件总数
        private int _failedCount; //压缩失败文件总数
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _compressHelper.Compressed += StartCompressed;
            _compressHelper.EndCompress += EndCompressed;
        }

        /// <summary>
        /// 浏览发布目录
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var folder = new FolderBrowserDialog();
            try
            {
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    btnCompress.Enabled = true;
                    lblTotalCount.Text = string.Empty;
                    lblCompletedCount.Text = string.Empty;
                    lblFailedCount.Text = string.Empty;
                    lblPrecent.Text = "0%";
                    _fileList.Clear();
                    _completedCount = 0;
                    _totalCount = 0;
                    _failedCount = 0;
                    pbCompress.Minimum = 0;
                    pbCompress.Value = 0;
                    txtPath.Text = folder.SelectedPath;
                    foreach (var file in Directory.GetFiles(folder.SelectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(p => (cbJs.Checked && p.EndsWith(".js"))
                                         || (cbCss.Checked && p.EndsWith(".css"))
                                         || (cbHtml.Checked && p.EndsWith(".html"))))
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

                        if (File.Exists(file) && File.ReadAllText(file).Length > 0)
                            _fileList.Add(file);
                    }
                    _totalCount = _fileList.Count();
                    lblTotalCount.Text = string.Format("文件总数：{0}", _totalCount);
                    pbCompress.Maximum = _totalCount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 压缩
        /// </summary>
        private void btnCompress_Click(object sender, EventArgs e)
        {
            _failedCount = 0;

            //var file = @"C:\Users\Administrator\Desktop\ALGroup\前端压缩工具\Test\test.css";
            //_compressHelper.StartCompress(file, "css");

            //var file = @"C:\Users\Administrator\Desktop\ALGroup\前端压缩工具\Test\test.js";
            //_compressHelper.StartCompress(file, "js");

            btnCompress.Enabled = false;
            StartCompress();
        }

        /// <summary>
        /// 开始压缩
        /// </summary>
        private void StartCompress()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    var fileList = _fileList.ToList();
                    //压缩
                    foreach (var file in fileList)
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        /// <summary>
        /// 压缩事件
        /// </summary>
        private void StartCompressed(object sender, EventArgs e)
        {
            var args = e as CompressArgs;
            if (args == null) return;
            try
            {
                var data = File.ReadAllText(args.FileFullname);
                switch (args.FileType)
                {
                    case "js":
                        args.Data = OschinaCompress.JsCompressMinifier(data);
                        break;
                    case "css":
                        args.Data = OschinaCompress.CssCompress(data);
                        break;
                    case "html":
                        args.Data = OschinaCompress.HtmlCompress(data);
                        break;
                }
            
                args.Data = string.IsNullOrEmpty(args.Data) ? args.Data : args.Data.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                //args.Data = ReduceMultiCommnet(args.Data);
                args.IsSuccess = true;
            }
            catch (Exception ex)
            {
                args.IsSuccess = false;
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 异步压缩完成
        /// </summary>
        private void EndCompressed(object sender, EventArgs e)
        {
            var args = e as CompressArgs;
            if (args == null) return;
            try
            {
                if (args.IsSuccess) ///
                {
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        File.WriteAllText(args.FileFullname, args.Data);
                    }
                    _fileList.Remove(args.FileFullname);
                    _completedCount++;
                }
                else
                {
                    _failedCount++;
                    Console.WriteLine(args.FileFullname);
                }


                BeginInvoke(new Action(() =>
                {
                    lblCompletedCount.Text = string.Format("已压缩文件：{0}", _completedCount);
                    lblFailedCount.Text = string.Format("压缩失败：{0}", _failedCount);
                    lblPrecent.Text = (_completedCount / (_totalCount * 1.0)).ToString("00.00%");
                    pbCompress.Value = _completedCount;
                }));

                if (_totalCount > 0 && _failedCount > 0 && (_totalCount == _completedCount + _failedCount))
                {
                    //已遍历所有文件,如果还存在没有被压缩的文件则继续压缩
                    Invoke(new Action(() =>
                    {
                        btnCompress.Enabled = true;
                        if (MessageBox.Show(string.Format("有{0}个文件压缩失败,是否保存文件名或重新压缩", _failedCount), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            var failedFile = Environment.CurrentDirectory + @"\failed.txt";
                            if (File.Exists(failedFile)) File.Delete(failedFile);
                            File.AppendAllLines(failedFile, _fileList);
                            MessageBox.Show(string.Format("已保存至文件：{0}", failedFile));
                        }
                    }));
                    //_failedCount = 0;
                    //StartCompress();
                }
            }
            catch (Exception ex)
            {
                //
                Console.WriteLine(ex.Message);
            }
        }


        private string ReduceMultiCommnet(string context)
        {
            var startIndexs = context.IndexOf("/*");
            Stack<int> symbolStack = new Stack<int>();
            var length = context.Length;
            for (var i = 0; i < length - 1; i++)
            {
                string symbol = context.Substring(i, 2);
                if (symbol == "/*")
                {
                    symbolStack.Push(i);
                }
                else if (symbol == "*/" && symbolStack.Count > 0)
                {
                    var start = symbolStack.Pop();
                    context = context.Remove(start, i - start + 2);
                    length = context.Length;
                }
            }
            return context;
        }
    }
}
