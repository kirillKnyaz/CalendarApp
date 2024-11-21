using System;
using System.Collections.Generic;

namespace CalendarApp.Models
{
    public partial class Recurrence
    {
        public Recurrence()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public string RecurrencePattern { get; set; }
        public int RecurrenceInterval { get; set; }
        public int? EndAfter { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}
