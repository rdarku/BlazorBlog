using BlazorBlog.Models.Likes;
using BlazorBlog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace BlazorBlog.WebAPI.Controllers
{
    [Authorize]
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new LikeService(userId);
        }

        public IHttpActionResult Get()
        {
            var service = CreateLikeService();
            return Ok(service.GetAll());
        }

        public IHttpActionResult Post(LikeCreate model)
        {
            var service = CreateLikeService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!service.CreateLike(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var service = CreateLikeService();
            return Ok(service.GetById(id));
        }

        // We probably do not want this here
        //public IHttpActionResult Put(LikeEdit comment)
        //{
        //    var service = CreateLikeService();
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    if (!service.UpdateLike(comment))
        //        return InternalServerError();

        //    return Ok();
        //}

        public IHttpActionResult Delete(int id)
        {
            var service = CreateLikeService();
            if (!service.DeleteLike(id))
                return InternalServerError();

            return Ok();
        }
    }
}
