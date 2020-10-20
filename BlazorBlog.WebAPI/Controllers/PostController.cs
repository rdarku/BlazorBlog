using BlazorBlog.Models.Post;
using BlazorBlog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace BlazorBlog.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            return new PostService(userId);
        }

        public IHttpActionResult Get()
        {
            PostService postservice = CreatePostService();
            var posts = postservice.Getposts();
            return Ok(posts);
        }

        public IHttpActionResult Post(PostCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PostService postservice = CreatePostService();

            if (!postservice.CreatePost(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            PostService postservice = CreatePostService();
            var post = postservice.GetById(id);
            return Ok(post);
        }

        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PostService postservice = CreatePostService();

            if (!postservice.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            PostService postservice = CreatePostService();

            if (!postservice.DeletePost(id))
                return InternalServerError();

            return Ok();
        }
    }
}
