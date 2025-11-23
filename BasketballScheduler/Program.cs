using BasketballScheduler.Config;
using BasketballScheduler.Services;
using BasketballScheduler.Models;

var teams = new List<Team>
{
    new Team("Hawks", 4), new Team("Falcons", 4),
    new Team("Hawks", 5), new Team("Lions", 5),  //fix: duplicate name for different grade should be okay
    new Team("Eagles", 8), new Team("Bears", 8),
    new Team("Wolves", 11), new Team("Tigers", 11)
};

//validation method (could be moved to a service later)
static void ValidateTeams(List<Team> teams)
{
    if (teams == null || teams.Count == 0)
        throw new ArgumentNullException("Teams list cannot be null or empty.", nameof(teams));
    //track name and grade
    var nameSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    foreach (var t in teams)
    {
        //check name & grade combination
        var key = $"{t.Name}|{t.Grade}";
        if (!nameSet.Add(key))
            throw new ArgumentException($"Duplicate team found: {t.Name} in grade {t.Grade}");
        //check grade range
        if (t.Grade < 1 || t.Grade > 12)
            throw new ArgumentOutOfRangeException($"Team {t.Name} has invalid grade: {t.Grade}");
    }
}

var config = new SchedulerConfig
{
    Day = DateTime.Today,
    StartTime = new TimeSpan(8, 0, 0),   // 8:00 AM
    EndTime = new TimeSpan(18, 0, 0),    // 6:00 PM
    SlotMinutes = 60,                    // 1 hour slots
    CourtCount = 2                       // 2 courts
};

// validate
ValidateTeams(teams);
config.Validate();
// generate time slots
var slotService = new TimeSlotService();
var slots = slotService.GenerateSlots(config);
//schdeule games
var scheduler = new Scheduler();
var games = scheduler.CreateSchedule(teams, slots);

Console.WriteLine("Basketball Schedule:");
foreach (var game in games)
{
    Console.WriteLine(game);
}

// // generate slots using Service
// var service = new TimeSlotService();
// var slots = service.GenerateSlots(config);

// Console.WriteLine("Generated schedule:");
// foreach (var slot in slots)
// {
//     Console.WriteLine(slot);
// }

//instantiate classes test
// using BasketballScheduler.Models;

// var teamA = new Team("Falcons", 6);
// var teamB = new Team("Tigers", 6);
// var slot = new TimeSlot(DateTime.Today.AddHours(9), 60, 1);
// var game = new Game(teamA, teamB, slot);
// Console.WriteLine(game);


