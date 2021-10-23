using System;

namespace RoundTheCode.FrontEndPostApi.Entites
{
    public class Comment
    {
        public int Id { get; set; } 

        public int PostId {  get; set; }

        public string Message {  get; set; }    

        public DateTime Created {  get; set; }  
    }
}
