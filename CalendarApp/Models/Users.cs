using System;
using System.Collections.Generic;

namespace CalendarApp.Models
{
    public partial class Users
    {
        public Users()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}
