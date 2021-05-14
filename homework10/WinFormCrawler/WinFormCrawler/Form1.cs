using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace WinFormCrawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void countUrl_label_Click(object sender, EventArgs e)
        {

        }

        private void crawl_button_Click(object sender, EventArgs e)
        {
            urlresult = "";
            startUrl = startUrl_textBox.Text;
            maxcount = int.Parse(countUrl_textBox.Text);
            urls[startUrl] = false;

            Crawl();
        }
        public string startUrl;
        public string urlresult; 
        public Hashtable urls = new Hashtable();
        public List<Task> tasks = new List<Task>();
        public int count = 1;
        public int maxcount;
        WebClient webClient = new WebClient();
        public void Crawl()
        {
            urlresult += "开始爬行:\r\n";
            Parse(webClient.DownloadString(startUrl));//解析当前页面的有效超链接
        }

        public void DownLoad(string url,int count)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);

                urlresult += "\r\n" + url + "頁面"+"爬取成功!";
            }
            catch (Exception ex)
            {
                urlresult += "\r\n" + url + "頁面" + "爬取失败";
                urlresult += ex.Message+"\r\n";
                count--;
            }

        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                string url = startUrl;
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                
                if (strRef.Length == 0) continue;

                if (!new Regex("(html|aspx|jsp)$").IsMatch(strRef)){ //限定爬取的页面
                    //urlresult += "拒绝的页面" + strRef;
                    continue; 
                }
                
                
                if (strRef.StartsWith("//"))
                {
                    strRef = url.Substring(0, url.IndexOf('/')) + strRef;
                }
                
                //将相对地址转换为绝对地址
                if (new Regex(url).IsMatch("/$")) url = url.Substring(0, url.Length - 1);
                if (new Regex(strRef).IsMatch("^/")) strRef = url + strRef;
                url = url.Substring(0, url.LastIndexOf('/'));
                if (new Regex(strRef).IsMatch("^./"))strRef = url + strRef.Substring(1);
                url = url.Substring(0, url.LastIndexOf('/'));
                if (new Regex(strRef).IsMatch("^../")) strRef = url+ strRef.Substring(2);
                if (urls[strRef] == null)
                {
                    urls[strRef] = false;
                    urlresult += "\r\n记录" + strRef;
                    if (count <= maxcount)
                    {
                        count++;
                        Task task = Task.Run(() => DownLoad(strRef,count));
                        tasks.Add(task);
                    }
                    else
                    {
                        Task.WaitAll(tasks.ToArray());
                        urlresult += "爬行结束!";
                        resultUrl_textBox.Text = urlresult;
                        break;
                    }
                }
                
                

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
    
    }
