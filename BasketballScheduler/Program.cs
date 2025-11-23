// See https://aka.ms/new-console-template for more information

using BasketballScheduler.Config;
using BasketballScheduler.Services;

var config = new SchedulerConfig
{
    Day = DateTime.Today,
    StartTime = new TimeSpan(9, 0, 0),   // 9:00 AM
    EndTime = new TimeSpan(12, 0, 0),    // 12:00 PM
    SlotMinutes = 60,                    // 1 hour slots
    CourtCount = 2                       // 2 courts
};

// validate
config.Validate();

// generate slots using Service
var service = new TimeSlotService();
var slots = service.GenerateSlots(config);

Console.WriteLine("Generated schedule:");
foreach (var slot in slots)
{
    Console.WriteLine(slot);
}



//instantiate classes test
// using BasketballScheduler.Models;

// var teamA = new Team("Falcons", 6);
// var teamB = new Team("Tigers", 6);
// var slot = new TimeSlot(DateTime.Today.AddHours(9), 60, 1);
// var game = new Game(teamA, teamB, slot);
// Console.WriteLine(game);


