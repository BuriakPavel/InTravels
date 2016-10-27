using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InTravels.WebAPI.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int LikesCount { get; set; }
        public string PublishDate { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public List<string> Tags { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}