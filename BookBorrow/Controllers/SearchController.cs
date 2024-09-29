using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookBorrow.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        [Route("api/search/{str}")]
        public HttpResponseMessage Search(string str)
        {
            try
            {
                var data = SearchService.Search(str);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
