using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HtmlGet
{
    public class HtmlParse
    {
        private readonly string mHtml;

        public HtmlParse(string html)
        {
            if (String.IsNullOrEmpty(html))
            {
                throw new Exception("Parameters html cannot be empty.");
            }
            this.mHtml = html;
        }

        public List<string> GetNodeByTagName(string name)
        {
            string patter = String.Format(ParseRegex.GETNODEBYTAGNAMM, name);
            return this.RegexMatch(patter);
        }

        public List<string> GetNodeByClass(string @class)
        {
            string patter = String.Format(ParseRegex.GETNODEBYCLASS, @class);
            return this.RegexMatch(patter);
        }

        //public List<string> GetNodeById(string id)
        //{

        //}

        public List<string> GetHref()
        {
            string patter = ParseRegex.HREF;
            return this.RegexMatch(patter);
        }

        //public List<string> GetSrc()
        //{

        //}

        //public List<string> GetImage()
        //{

        //}

        //public string ToList()
        //{

        //}

        public string ToText()
        {
            string patter = ParseRegex.TAG;
            Regex regex = new Regex(patter);
            return regex.Replace(this.mHtml, "");
        }

        private List<string> RegexMatch(string patter)
        {
            Regex regex = new Regex(patter);
            MatchCollection matchs = regex.Matches(this.mHtml);
            List<string> result = new List<string>();
            foreach (Match match in matchs)
            {
                result.Add(match.Value);
            }
            return result;
        }
    }
}
