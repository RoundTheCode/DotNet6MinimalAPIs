using System;

namespace RoundTheCode.FrontEndPostApi.Entites
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Article {  get; set; }

        public string Slug {  get; set; }

        public DateTime Published {  get; set; }
    }
}
