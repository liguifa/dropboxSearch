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
            { "百度网盘",WebSiteInfo.Baidu},
            //{ "华为网盘",WebSiteInfo.Huawei},
            //{ "CSDN",WebSiteInfo.Csdn}
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
            Order(ref resoure);
            string json = JsonConvert.SerializeObject(resoure);
            return json;
        }

        public static void Order(ref List<ResoureInfo> resoures)
        {
            Random random = new Random();
            for (int i = 0; i < resoures.Count; i++)
            {
                int num = random.Next(0, resoures.Count);
                ResoureInfo temp = resoures[i];
                resoures[i] = resoures[num];
                resoures[num] = temp;
            }
        }
    }
}
