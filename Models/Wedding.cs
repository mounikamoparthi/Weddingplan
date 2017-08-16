using System;
using System.Collections.Generic;
using wedding_planner.Models;

namespace wedding_planner.Models
{
    public class Wedding : BaseEntity
    {
        public int WeddingId { get; set; }
        public string SpouseOne { get; set; }
        public string SpouseTwo { get; set; }
        public int UserId {get; set;}
        public User user {get; set;}
        public string WeddingAddress {get; set;}
        public DateTime WeddingDate { get; set; }
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt { get; set;}
         public List<Invitation> Invitations { get; set; }
 
        public Wedding()
        {
            Invitations = new List<Invitation>();
        }
        
    }
}
    