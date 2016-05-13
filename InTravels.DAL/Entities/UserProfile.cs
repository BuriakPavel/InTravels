using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InTravels.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public enum Gender : int
    {
        Male = 0, Female = 1
    }
}