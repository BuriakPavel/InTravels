using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InTravels.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public DateTime Date { get; set; }
    }
}