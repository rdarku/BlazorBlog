using BlazorBlog.Data;
using BlazorBlog.Models.Replies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBlog.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var replyEntity = new Reply   
            {
                Text = model.Text,
                PostId = model.PostID,
                CommentId = model.CommentId,
                ApplicationUserId = _userId.ToString(),
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(replyEntity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateComment(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var replyEntity = ctx.Replies.Single(p => p.ReplyId == model.ReplyId && p.ApplicationUserId == _userId.ToString());
                if (replyEntity == null) return false;

                replyEntity.Text = model.Text;
                replyEntity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReply(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var replyEntity = ctx.Replies.Single(p => p.ReplyId == id && p.ApplicationUserId == _userId.ToString());
                if (replyEntity == null) return false;

                ctx.Replies.Remove(replyEntity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Replies.Where(p => p.ApplicationUserId == _userId.ToString())
                    .Select(p => new ReplyListItem
                    {
                        ReplyId = p.Id,
                        PostId = p.PostId,
                        CommentId = p.CommentId,
                        CreatedUtc = p.CreatedUtc
                    }).ToList();
            }
        }

        public ReplyDetail GetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var postEntity = ctx.Replies.Single(p => p.ReplyId == id && p.ApplicationUserId == _userId.ToString());
                if (postEntity == null) return null;

                return new ReplyDetail
                {
                    ReplyId = postEntity.ReplyId,
                    Reply = postEntity.Text,
                    CommentAuthor = postEntity.Author.UserName,
                    ReplyAuthor = postEntity.Author.UserName,
                    PostId = postEntity.PostId,
                    CreatedUtc = postEntity.CreatedUtc,
                    CommentId = postEntity.CommentId
                };
            }
        }
    }
}
