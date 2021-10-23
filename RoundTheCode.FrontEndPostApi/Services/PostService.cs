using RoundTheCode.FrontEndPostApi.Entites;
using System.Collections.Generic;
using System.Linq;

namespace RoundTheCode.FrontEndPostApi.Services
{  
    public class PostService : IPostService
    {
        protected IDictionary<int, Post> Posts { get; set; }

        protected int NextId { get; set; }

        public PostService()
        {
            Posts = new Dictionary<int, Post>();

            Posts.Add(1, new Post
            {
                Id = 1,
                Title = "Announcing our new CEO",
                Article = "Our new CEO has been announced as Jim White. Jim has had 20 years background, running various companies across the globe.",
                Slug = "announcing-our-ceo",
                Published = new System.DateTime(2021, 9, 21)
            });

            Posts.Add(2, new Post
            {
                Id = 2,
                Title = "A new deal worth over $100,000",
                Article = "We have signed a new deal with a big company that is worth over $100,000!",
                Slug = "new-deal-worth-over-usd-100000",
                Published = new System.DateTime(2021, 9, 29)
            });

            NextId = Posts.Count() + 1;
        }

        public IList<Post> ReadAll()
        {
            return Posts.Values.ToList();
        }


        public Post ReadById(int id)
        {
            if (!Posts.ContainsKey(id))
            {
                return null;
            }

            return Posts[id];
        }

        public Post ReadBySlug(string slug)
        {
            return Posts.Values.FirstOrDefault(x => x.Slug == slug);
        }

    }
}
