using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.DAL.Entities
{
    public class TravelCategory
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public string IconPath { get; set; }
        [MaxLength(5)]
        public string LocaleCode { get; set; }
    }
}
