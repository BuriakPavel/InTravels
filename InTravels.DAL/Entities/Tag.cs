using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.DAL.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(15)]
        public string Title { get; set; }
        [MaxLength(5)]
        public string LocaleCode { get; set; }
    }
}
