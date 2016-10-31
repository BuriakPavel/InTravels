using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.DAL.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("UserProfile")]
        public string UserProfileId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }
        public int? Likes { get; set; }

        public virtual TravelCategory Category { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
