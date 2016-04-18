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
        public string Search(string key)
        {
            return String.Format(@"{{""rows"":{0}}}",SearchManager.Search(key));
        }
    }
}