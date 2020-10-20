using BlazorBlog.Models.Comments;
using BlazorBlog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace BlazorBlog.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        private readonly CommentService _service;
        public CommentController()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            _service = new CommentService(userId);
        }
 

        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        public IHttpActionResult Post(CommentCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            if (!_service.CreateComment(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_service.GetById(id));
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_service.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
