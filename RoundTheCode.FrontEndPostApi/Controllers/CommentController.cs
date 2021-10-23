using Microsoft.AspNetCore.Mvc;
using RoundTheCode.FrontEndPostApi.Entites;
using RoundTheCode.FrontEndPostApi.Extensions;
using RoundTheCode.FrontEndPostApi.Models;
using RoundTheCode.FrontEndPostApi.Services;
using System.Collections.Generic;

namespace RoundTheCode.FrontEndPostApi.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        protected IPostService _postService;
        protected ICommentService _commentService;

        public CommentController(IPostService postService, ICommentService commentService)
        {
            _postService = postService.NotNull();
            _commentService = commentService.NotNull();
        }

        [HttpGet("{postId}")]
        public virtual ActionResult<IList<Comment>> ReadAllByPost(int postId)
        {
            var post = _postService.ReadById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(_commentService.ReadAllByPost(postId));
        }

        [HttpPost]
        public virtual Comment Create([FromBody] CreateComment createComment)
        {
            return _commentService.Create(createComment);
        }
    }
}
