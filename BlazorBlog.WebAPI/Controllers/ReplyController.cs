using BlazorBlog.Models.Replies;
using BlazorBlog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace BlazorBlog.WebAPI.Controllers
{
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new ReplyService(userId);
        }

        public IHttpActionResult Get()
        {
            var service = CreateReplyService();
            return Ok(service.GetAll());
        }

        public IHttpActionResult Post(ReplyCreate model)
        {
            var service = CreateReplyService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!service.CreateReply(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var service = CreateReplyService();
            return Ok(service.GetById(id));
        }

        public IHttpActionResult Put(ReplyEdit comment)
        {
            var service = CreateReplyService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!service.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();
            if (!service.DeleteReply(id))
                return InternalServerError();

            return Ok();
        }
    }
}
