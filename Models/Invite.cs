using System;
using System.Collections.Generic;
using wedding_planner.Models;

namespace wedding_planner.Models
{
    public class Invite : BaseEntity
    {
        //public int InviteId { get; set; }
 
        public int UserId { get; set; }
        public User user { get; set; }
 
        public int WeddingId { get; set; }
        public Wedding wedding { get; set; }
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }
}