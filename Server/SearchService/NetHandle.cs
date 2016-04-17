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

        public NetHandle(string webSiteName,string webSiteUrl, string key)
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
            string regexStr = "<li\\sclass=\"b_algo\"\\sdata-bm=\"[0 - 9]{ 1,2}\">.*</li>*";
            Regex regex = new Regex(regexStr);
            Match match = regex.Match(html);
            if(match!=null)
            {
                string temp = match.Value;
            }
            return null;
        }
    }
}
