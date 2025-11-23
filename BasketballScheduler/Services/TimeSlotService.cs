//generates time slots across multiple courts
using BasketballScheduler.Config;
using BasketballScheduler.Models;
using System;

namespace BasketballScheduler.Services
{
    public class TimeSlotService
    {
        public List<TimeSlot> GenerateSlots(SchedulerConfig config)
        {
        //list to hold slots
        var slots = new List<TimeSlot>();
        //start at configured start time
        var current = config.GetStartDateTime();

        //loop until end time
        while (current < config.GetEndDateTime()){
            //create slot for each court
            for (int court = 1; court <= config.CourtCount; court++)
            {
                //add new slot to list
                slots.Add(new TimeSlot(current, config.SlotMinutes, court));
            }
            //move to next slot time
            current = current.AddMinutes(config.SlotMinutes);
        }
        //return complete list
        return slots;
        }
    }
}