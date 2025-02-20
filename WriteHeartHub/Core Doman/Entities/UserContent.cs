using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Doman.Entities
{
    public class UserContent

    {

        public int Id { get; set; } 
        public string UserId { get; set; } 
        public ContentType Type { get; set; } 

        public string Content { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public List<string> Tags { get; set; } // Optional tags for categorization


        public UserContent()
        {

            Tags = new List<string>();

            CreatedAt = DateTime.UtcNow;

        }

    }


    public enum ContentType

    {

        Post,

        Story,

        Thought,

        Quote,

        Lyrics

    }
}
//Sharimsg_id,AccountID,Shayritext,IsDelete