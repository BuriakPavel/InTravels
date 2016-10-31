using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.DAL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Post")]
        public int? PostId { get; set; }

        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }

        [ForeignKey("UserProfile")]
        public string UserProfileId { get; set; }

        public string Text { get; set; }
        public DateTime? Date { get; set; }
        public int? Likes { get; set; }

        public virtual Post Post { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
