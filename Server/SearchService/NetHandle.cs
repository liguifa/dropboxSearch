using HtmlGet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchService
{
    public class NetHandle
    {
        private string mWebSiteUrl;
        private string mWebSiteName;
        private string mKey;

        public NetHandle(string webSiteName, string webSiteUrl, string key)
        {
            this.mWebSiteUrl = webSiteUrl;
            this.mWebSiteName = webSiteName;
            this.mKey = key;
        }

        public List<ResoureInfo> GetResoure()
        {
            string searchUrl = String.Format("http://cn.bing.com/search?q={0}+{1}", this.mWebSiteUrl, this.mKey);
            string html = this.GetHtml(searchUrl);
            return this.ParseHtml(html);
        }

        private string GetHtml(string url)
        {
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(url);
            StreamReader sr = new StreamReader(stream);
            string html = sr.ReadToEnd();
            return html;
        }

        private List<ResoureInfo> ParseHtml(string html)
        {
            List<ResoureInfo> resoures = new List<ResoureInfo>();
            HtmlParse parse = new HtmlParse(html);
            List<string> nodes = parse.GetNodeByTagName("li");
            foreach (string node in nodes)
            {
                ResoureInfo resoure = new ResoureInfo();
                parse = new HtmlParse(node);
                List<string> titles = parse.GetNodeByTagName("h2");
                if (titles.Count > 0)
                {
                    HtmlParse nodeParse = new HtmlParse(titles.First());
                    resoure.Title = nodeParse.ToText().Replace(@"""", "'"); ;
                }
                else
                {
                    continue;
                }
                List<string> introductions = parse.GetNodeByTagName("p");
                if (introductions.Count > 0)
                {
                    HtmlParse nodeParse = new HtmlParse(introductions.First());
                    resoure.Introduction = nodeParse.ToText().Replace(@"""","");
                }
                else
                {
                    continue;
                }
                List<string> hrefs = parse.GetHref();
                if (hrefs.Count > 0)
                {
                    resoure.Url = hrefs.First();
                }
                else
                {
                    continue;
                }
                resoure.WebSite = this.mWebSiteName;
                resoures.Add(resoure);
            }
            return resoures;
        }
    }
}
