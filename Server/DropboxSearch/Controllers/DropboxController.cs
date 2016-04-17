using SearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropboxSearch.Controllers
{
    public class DropboxController : Controller
    {
        // GET: Dropbox
        [HttpGet]
        public string Search(string key, string jsonpcallbadk)
        {
            return String.Format("{0}({1})", jsonpcallbadk, SearchManager.Search(key));
        }
    }
}