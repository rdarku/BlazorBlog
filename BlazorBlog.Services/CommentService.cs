using BlazorBlog.Data;
using BlazorBlog.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBlog.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var commentEntity = new Comment
            {
                Text = model.Text,
                PostId = model.PostId, 
                ApplicationUserId = _userId.ToString(),
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(commentEntity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var commentEntity = ctx.Comments.Single(p => p.Id == model.Id && p.ApplicationUserId == _userId.ToString());
                if (commentEntity == null) return false;

                commentEntity.Text = model.Text;
                commentEntity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var commentEntity = ctx.Comments.Single(p => p.Id == id && p.ApplicationUserId == _userId.ToString());
                if (commentEntity == null) return false;

                ctx.Comments.Remove(commentEntity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Comments.Where(p => p.ApplicationUserId == _userId.ToString())
                    .Select(p => new CommentListItem
                    {
                        Id = p.Id,
                        PostId = p.PostId,
                        CommentAuthor = p.Author.UserName
                    }).ToList();
            }
        }

        public CommentDetail GetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var postEntity = ctx.Comments.Single(p => p.Id == id && p.ApplicationUserId == _userId.ToString());
                if (postEntity == null) return null;

                return new CommentDetail
                {
                    Id = postEntity.Id,
                    Text = postEntity.Text,
                    CommentAuthor = postEntity.Author.UserName,
                    PostId = postEntity.PostId,
                    PostAuthor = postEntity.CommentPost.Author.UserName
                };
            }
        }
    }
}
