//Time Complexity: O(S x C) ; Linear Time |
using System;
//<summary>
//Configuration for scheduling constraints and environment | Centralizes environment to prevent hardcoding values. 
//</summary>
namespace BasketballScheduler.Config
{
    public class SchedulerConfig
    {
        public DateTime Day{get; set; } = DateTime.Now;
        public TimeSpan StartTime { get; set; } = new(8, 0, 0); // 8:00 AM
        public TimeSpan EndTime { get; set; } = new(18, 0, 0); // 8:00 PM
        public int SlotMinutes { get; set; } = 60; // 1 hour slots
        public int CourtCount{get; set; } = 1; // Number of available courts

        //full date time
        public DateTime GetStartDateTime() => Day.Date + StartTime;
        public DateTime GetEndDateTime() => Day.Date + EndTime;
    }
}