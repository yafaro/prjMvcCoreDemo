using System.ComponentModel.DataAnnotations;

namespace prjMvcCoreDemo.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string tContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
