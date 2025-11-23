//Time Complexity: O(S x C) ; Linear Time |

//generates time slots across multiple courts
using BasketballScheduler.Config;
using BasketballScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketballScheduler.Services
{
    public class TimeSlotService
    {
        public List<TimeSlot> GenerateSlots(SchedulerConfig config)
        {
            config.Validate();

            var start = config.GetStartDateTime();
            var end = config.GetEndDateTime();
            var totalMinutes = (end - start).TotalMinutes;

            // slot intervals
            var S = (int)(totalMinutes / config.SlotMinutes);
            var C = config.CourtCount;

            // pre-size list
            var slots = new List<TimeSlot>(S * C);

            var current = start;
            for (int i = 0; i < S; i++)
            {
                for (int court = 1; court <= C; court++)
                {
                    slots.Add(new TimeSlot(current, config.SlotMinutes, court));
                }
                current = current.AddMinutes(config.SlotMinutes);
            }

            return slots;
        }
        //could add court filtering method here later
    }
}
