using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InTravels.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }
        public string PublishDate { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public List<CommentViewModel> Answers { get; set; }
    }
}