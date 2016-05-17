using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public int ParentCommentId { get; set; }
        public DateTime Date { get; set; }
        public int Likes { get; set; }
    }
}
