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
            resultUrl_textBox.Text = "";
            startUrl = startUrl_textBox.Text;
            maxcount = int.Parse(countUrl_textBox.Text);
            urls[startUrl] = false;
            Parallel.Invoke(Crawl);//
            //Crawl();
        }
        public string startUrl;
        public Hashtable urls = new Hashtable();
        public int count = 1;
        public int maxcount;
        WebClient webClient = new WebClient();
        public void Crawl()
        {
            resultUrl_textBox.Text += "开始爬行:\r\n";
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                    break;
                }
                if (current == null || count > maxcount) break;
                resultUrl_textBox.Text +="爬行" + current + "页面!";
                DownLoad(current);
                urls[current] = true;
                count++;
                Parse(webClient.DownloadString(startUrl));//只在指定网站爬取网页
            }
            resultUrl_textBox.Text += "爬行结束!";
        }

        public void DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                resultUrl_textBox.Text += "爬取成功！\r\n";
            }
            catch (Exception ex)
            {
                resultUrl_textBox.Text += "爬取失败";
                resultUrl_textBox.Text += ex.Message+"\r\n";
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
                    //resultUrl_textBox.Text += "拒绝的页面" + strRef;
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
                    resultUrl_textBox.Text += "记录改" + strRef;
                    break;//每次只解析一个超链接
                }
                    

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
    }
