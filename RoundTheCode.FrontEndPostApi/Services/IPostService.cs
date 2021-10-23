using RoundTheCode.FrontEndPostApi.Entites;
using System.Collections.Generic;

namespace RoundTheCode.FrontEndPostApi.Services
{
    public interface IPostService
    {
        IList<Post> ReadAll();

        Post ReadById(int id);
        Post ReadBySlug(string slug);
    }
}
