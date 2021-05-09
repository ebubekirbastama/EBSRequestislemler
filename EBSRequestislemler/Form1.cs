using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System.Linq;

namespace EBSRequestislemler
{
    public partial class Form1 : Form
    {
        private string pagesource;

        public Form1()
        {
            InitializeComponent();
        }
        //Coding By Ebubekir Bastama

        //Cookie için Değerler
        //Name
        //Value
        //Path('/')
        //url
        string URL = "";
        HtmlAgilityPack.HtmlDocument html;
        CookieContainer cookie = new CookieContainer();
        private void button1_Click(object sender, EventArgs e)
        {

            Cookie c = new Cookie("Name", "Value", "/", "siteismi.com");
            cookie.Add(c);

           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.CookieContainer = cookie;

            WebResponse wbb = request.GetResponse();
            using (Stream responsestream = wbb.GetResponseStream())
            {
                StreamReader rdr = new StreamReader(responsestream,Encoding.Default,true);
                pagesource = rdr.ReadToEnd();
            }
            html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(pagesource);
            HtmlNode[] nodes = html.DocumentNode.SelectNodes("Xpath Değeri").ToArray();
            foreach (var item in nodes)
            {
                richTextBox1.AppendText(item.InnerText + "\r");
            }
        }
    }
}
