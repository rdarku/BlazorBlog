using BlazorBlog.Data;
using BlazorBlog.Models.Likes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBlog.Services
{
    public class LikeService
    {
        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLike(LikeCreate model)
        {
            var likeEntity = new Like
            {
                PostId = model.PostId,
                ApplicationUserId = _userId.ToString()
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(likeEntity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateLike(LikeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var likeEntity = ctx.Likes.Single(p => p.Id == model.Id && p.ApplicationUserId == _userId.ToString());
                if (likeEntity == null) return false;

                likeEntity.PostId = model.PostId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLike(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var likeEntity = ctx.Likes.Single(p => p.Id == id && p.ApplicationUserId == _userId.ToString());
                if (likeEntity == null) return false;

                ctx.Likes.Remove(likeEntity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LikeListItem> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Likes.Where(p => p.ApplicationUserId == _userId.ToString())
                    .Select(p => new LikeListItem
                    {
                        Id = p.Id,
                        PostId = p.PostId,
                        Liker = p.Liker.UserName
                    }).ToList();
            }
        }

        public LikeListItem GetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var postEntity = ctx.Likes.Single(p => p.Id == id && p.ApplicationUserId == _userId.ToString());
                if (postEntity == null) return null;

                return new LikeListItem
                {
                    Id = postEntity.Id,
                    PostId = postEntity.PostId,
                    Liker = postEntity.Liker.UserName
                };
            }
        }
    }
}
