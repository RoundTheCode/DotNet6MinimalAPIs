using RoundTheCode.FrontEndPostApi.Entites;
using RoundTheCode.FrontEndPostApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoundTheCode.FrontEndPostApi.Services
{
    public class CommentService : ICommentService
    {
        protected IDictionary<int, Comment> Comments { get; set; }

        protected int NextId { get; set; }

        public CommentService()
        {
            Comments = new Dictionary<int, Comment>();

            NextId = Comments.Count() + 1;
        }

        public Comment Create(CreateComment createComment)
        {
            var comment = new Comment
            {
                Id = NextId,
                PostId = createComment.PostId,
                Message = createComment.Message,
                Created = DateTime.Now
            };

            Comments.Add(NextId, comment);

            NextId++;

            return comment;
        }

        public IList<Comment> ReadAllByPost(int postId)
        {
            return Comments.Values.Where(p => p.PostId == postId).ToList();
        }
    }
}
