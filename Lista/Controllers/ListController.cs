using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using Lista.Services;

namespace Lista.Controllers
{
    public class ListController : ApiController
    {
        private IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        // GET: api/List
        public IEnumerable<string> GetList()
        {
            return _listService.ReadListFromFile();
        }

        // POST: api/List
        public IHttpActionResult AddItem(HttpRequestMessage value)
        {
            string result = value.Content.ReadAsStringAsync().Result;

            result = StringHelper.ReplaceAllDecimalToHex(result);
            result = StringHelper.RemoveDiacritics(result);

            _listService.AddToFile(result);
            return Ok(result);
        }

        // DELETE: api/List
        public void Delete()
        {
            _listService.ClearListFile();
        }
    }
}
