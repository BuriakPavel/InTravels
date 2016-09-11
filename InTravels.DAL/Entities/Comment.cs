using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Post Post { get; set; }
        public Comment ParentComment { get; set; }
        public DateTime Date { get; set; }
        public int Likes { get; set; }
        public string UserId { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
