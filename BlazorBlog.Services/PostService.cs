using BlazorBlog.Data;
using BlazorBlog.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBlog.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        // create Post
        public bool CreatePost(PostCreate model)
        {
            var postEntity = new Post
            {
                Text = model.Text,
                Title = model.Title,
                UserId = _userId,
                CreatedUtc = DateTimeOffset.Now
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(postEntity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Update Post
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var postEntity = ctx.Posts.Single(p => p.Id == model.Id && p.UserId == _userId);
                if (postEntity == null) return false;

                postEntity.Title = model.Title;
                postEntity.Text = model.Text;
                postEntity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        // Get all Posts
        public IEnumerable<PostListItem> Getposts()
        {
            using(var ctx = new ApplicationDbContext())
            {
                return ctx.Posts.Where(p => p.UserId == _userId)
                    .Select(p => new PostListItem
                    {
                        Id = p.Id,
                        CreatedUtc = p.CreatedUtc,
                        Title = p.Title
                    }).ToList();
            }
        }

        // Get Post By ID
        public PostDetail GetById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var postEntity = ctx.Posts.Single(p => p.Id == id && p.UserId == _userId);
                if (postEntity == null) return null;

                return new PostDetail
                {
                    Id = postEntity.Id,
                    Title = postEntity.Title,
                    Text = postEntity.Text,
                    CreatedUtc = postEntity.CreatedUtc,
                    Username = postEntity.Author.UserName
                };
            }
        }

        // Delete Post
        public bool DeletePost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var postEntity = ctx.Posts.Single(p => p.Id == id && p.UserId == _userId);
                if (postEntity == null) return false;

                ctx.Posts.Remove(postEntity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
