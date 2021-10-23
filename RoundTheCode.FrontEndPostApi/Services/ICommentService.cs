using RoundTheCode.FrontEndPostApi.Entites;
using RoundTheCode.FrontEndPostApi.Models;
using System.Collections.Generic;

namespace RoundTheCode.FrontEndPostApi.Services
{
    public interface ICommentService
    {
        IList<Comment> ReadAllByPost(int postId);

        Comment Create(CreateComment createComment);
    }
}
