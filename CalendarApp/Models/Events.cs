using System;
using System.Collections.Generic;

namespace CalendarApp.Models
{
    public partial class Events
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? RecurrenceId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? NotifyTimeBefore { get; set; }
        public string NotifyStatus { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Category Category { get; set; }
        public virtual Recurrence Recurrence { get; set; }
        public virtual Users User { get; set; }
    }
}
