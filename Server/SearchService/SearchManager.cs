using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService
{
    public static class SearchManager
    {
        private static Dictionary<string, string> mWebSites = new Dictionary<string, string>()
        {
            { "百度网盘",WebSiteInfo.Baidu}
        };
        private static readonly object mSyncRoot = new object();

        public static string Search(string key)
        {
            List<ResoureInfo> resoure = new List<ResoureInfo>();
            Parallel.ForEach(mWebSites, web =>
            {
                NetHandle handle = new NetHandle(web.Key, web.Value, key);
                List<ResoureInfo> res = handle.GetResoure();
                lock (mSyncRoot)
                {
                    resoure = resoure.Concat(res).ToList();
                }
            });
            string json = JsonConvert.SerializeObject(resoure);
            return json;
        }
    }
}
