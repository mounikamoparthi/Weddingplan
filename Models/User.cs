using System;
using System.Collections.Generic;
using wedding_planner.Models;

namespace wedding_planner.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public List<Invitation> Invitations { get; set; }
 
        public User()
        {
            Invitations = new List<Invitation>();
        
        }
    }
}
    