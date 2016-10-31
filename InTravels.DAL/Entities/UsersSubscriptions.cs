using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.DAL.Entities
{
    public class UsersSubscriptions
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("UserProfile"), Column(Order = 0)]
        public string SubscriberId { get; set; }

        [ForeignKey("UserProfile"), Column(Order = 1)]
        public string SubscribtionId { get; set; }
    }
}
