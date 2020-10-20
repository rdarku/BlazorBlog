using BlazorBlog.Models.Comments;
using BlazorBlog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace BlazorBlog.WebAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new CommentService(userId);
        }

        public IHttpActionResult Get()
        {
            var service = CreateCommentService();
            return Ok(service.GetAll());
        }

        public IHttpActionResult Post(CommentCreate model)
        {
            var service = CreateCommentService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            if (!service.CreateComment(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var service = CreateCommentService();
            return Ok(service.GetById(id));
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            var service = CreateCommentService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!service.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();
            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
