using System;
using System.Collections.Generic;
using wedding_planner.Models;

namespace wedding_planner.Models
{
    public class Wedding : BaseEntity
    {
        public int WeddingId { get; set; }
        public string WeddingUser1 { get; set; }
        public string WeddingUser2 { get; set; }
        public int UserId {get; set;}
        public User user {get; set;}
        public string Address {get; set;}
        public DateTime WeddingDate { get; set; }
        public List<Invite> Invites { get; set; }
 
        public Wedding()
        {
            Invites = new List<Invite>();
        }
        
    }
}
    