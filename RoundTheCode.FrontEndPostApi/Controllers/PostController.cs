using Microsoft.AspNetCore.Mvc;
using RoundTheCode.FrontEndPostApi.Entites;
using RoundTheCode.FrontEndPostApi.Extensions;
using RoundTheCode.FrontEndPostApi.Services;
using System.Collections.Generic;

namespace RoundTheCode.FrontEndPostApi.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        protected IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService.NotNull();
        }

        [HttpGet]
        public virtual IList<Post> ReadAll()
        {
            return _postService.ReadAll();
        }

        [HttpGet("{slug}")]
        public virtual ActionResult<Post> ReadBySlug(string slug)
        {
            var post = _postService.ReadBySlug(slug);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

    }
}
