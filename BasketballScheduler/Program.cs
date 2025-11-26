using BasketballScheduler.Config;
using BasketballScheduler.Services;
using BasketballScheduler.Models;
using System.Text.Json;

namespace BasketballScheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {


                //load teams from JSON file or hardcoded list
                var teams = new List<Team>
                    {
                        new Team("Hawks", 4), new Team("Falcons", 4),
                        new Team("Hawks", 6), new Team("Lions", 5),
                        new Team("Eagles", 8), new Team("Bears", 8),
                        new Team("Wolves", 11), new Team("Tigers", 11)
                    };
                //validate team
                ValidateTeams(teams);
                //build schedule configuration
                var config = new SchedulerConfig
                {
                    Day = DateTime.Today,
                    StartTime = new TimeSpan(8, 0, 0),   // 8:00 AM
                    EndTime = new TimeSpan(18, 0, 0),    // 6:00 PM
                    SlotMinutes = 60,                    // 1 hour slots
                    CourtCount = 2                       // 2 courts
                };
                // validate
                config.Validate();
                // generate time slots
                var slotService = new TimeSlotService();
                var slots = slotService.GenerateSlots(config);
                //schdeule games
                var scheduler = new Scheduler();
                var games = scheduler.CreateSchedule(teams, slots);
                //print schedule
                Console.WriteLine("Basketball Schedule:");
                foreach (var game in games)
                {
                    Console.WriteLine(game);
                }
                //save schedule in JSON
                SaveScheduleAsJson(games, "schedule.json");
        }            


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
            //save schedule to JSON file
            static void SaveScheduleAsJson(List<Game> games, string path)
            {
                var dto = games.Select(g => new
                {
                    Home = g.Home.Name,
                    HomeGrade = g.Home.Grade,
                    Away = g.Away.Name,
                    AwayGrade = g.Away.Grade,
                    Start = g.Slot.Start,
                    End = g.Slot.End,
                    Court = g.Slot.CourtNumber
                }).ToList();
                var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
                Console.WriteLine($"Schedule saved to {path}");
            }

        }
    }



