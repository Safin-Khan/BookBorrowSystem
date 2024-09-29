using BLL.DTOs;
using BLL.Services;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BorrowBorrow.Controllers
{
    [RoutePrefix("api/borrows")]
    public class BorrowController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = BorrowingService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = BorrowingService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("user/{uid}")]
        public HttpResponseMessage GetbyUid(int uid)
        {
            try
            {
                var data = BorrowingService.GetbyUid(uid);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(BorrowingDTO obj)
        {
            try
            {
                var data = BorrowingService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(BorrowingDTO obj)
        {
            try
            {
                var data = BorrowingService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = BorrowingService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("search")]
        public IHttpActionResult SearchBorrowings(BorrowingRepo borrowingRepo, string bookTitle = null, string borrowerName = null)
        {
            var borrowings = borrowingRepo.Get();

            if (!string.IsNullOrEmpty(bookTitle))
            {
                borrowings = borrowings.Where(b => b.Book.Title.Contains(bookTitle)).ToList();
            }

            if (!string.IsNullOrEmpty(borrowerName))
            {
                borrowings = borrowings.Where(b => b.User.Username.Contains(borrowerName)).ToList();
            }

            return Ok(borrowings);
        }

    }
}
