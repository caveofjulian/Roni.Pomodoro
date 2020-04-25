using System;

namespace Roni.Pomodoro.Shared
{
    public class TimeBlock
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public TimeBlockCategory TimeBlockCategory { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsTerminated { get; set; }
        public string Description { get; set; }
    }
}
