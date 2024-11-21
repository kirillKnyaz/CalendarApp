using System;
using System.Collections.Generic;

namespace CalendarApp.Models
{
    public partial class Category
    {
        public Category()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}
