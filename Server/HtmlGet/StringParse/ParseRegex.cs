using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlGet
{
    public class ParseRegex
    {
        public const string GETNODEBYTAGNAMM = @"(?<=\<{0}[^>]*\>).*?(?=\<\/{0}>)";
        public const string GETNODEBYCLASS = @"(?<=\<.*\s{0,1}.*class=""{0}""[^>]*\>).*?(?=\<\/.*>)";
        public const string TAG = @"</{0,1}[^>]*>";
        public const string HREF = @"(?<=href="")[^""]*";
    }
}
