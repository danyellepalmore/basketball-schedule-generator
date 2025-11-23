// See https://aka.ms/new-console-template for more information
//instantiate classes test
using BasketballScheduler.Config;
using BasketballScheduler.Services;

var config = new SchedulerConfig
{
    Day = DateTime.Today,
    StartTime = new TimeSpan(9, 0, 0),
    EndTime = new TimeSpan(12, 0, 0),
    SlotMinutes = 60,
    CourtCount = 2
};

var service = new TimeSlotService();
var slots = service.GenerateSlots(config);
foreach (var s in slots) Console.WriteLine(s);

