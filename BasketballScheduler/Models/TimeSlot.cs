// Time Complexity: O(1) | keeps memory low and access time fast
using System;

namespace BasketballScheduler.Models
{
    public class TimeSlot
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public int CourtNumber { get; }
        // Constructor validation
        public TimeSlot(DateTime start, int durationMinutes, int courtNumber)
        {
            if (durationMinutes <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(durationMinutes), "Duration must be a positive integer.");
            }
            if (courtNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(courtNumber), "Court number must be a positive integer.");
            }

            // Assigning values to properties
            Start = start;
            End = start.AddMinutes(durationMinutes);  //calculate end time based on start time and duration
            CourtNumber = courtNumber;
        }
        public override string ToString() =>
            $"{Start:hh:mm tt} - {End:hh:mm tt} (Court {CourtNumber})";

    }
}