//Time complexity: O(n log n) due to sorting
//arrange games by lower grade first and pair teams
using System;
using System.Collections.Generic;
using System.Linq;
using BasketballScheduler.Models;

namespace BasketballScheduler.Services
{
    public class Scheduler
    {
        public List<Game> CreateSchedule(List<Team> teams, List<TimeSlot> slots)
        {
            //debugging
            if (teams == null || teams.Count ==0)
                throw new ArgumentNullException("Teams are required", nameof(teams));
            if (slots == null || slots.Count ==0)
                throw new ArgumentNullException("Time slots are required", nameof(slots));
            // sort teams by grade
            var sortedTeams = teams.OrderBy(t => t.Grade).ToList(); 

            // pairing logic: pair teams sequentially
            var pairs = new List<(Team Home, Team Away)>();
            for (int i = 0; i < sortedTeams.Count; i += 2)
            {
                pairs.Add((sortedTeams[i], sortedTeams[i + 1]));
            }
            //handle odd amount of teams
            Team? byeTeam = null;
            if (sortedTeams.Count % 2 != 0)
            {
                byeTeam = sortedTeams.Last();
            }

            //ensure enough slots
            if (pairs.Count > slots.Count)
                throw new InvalidOperationException("Not enough time slots for all games.");
            // index aligned mapping
            var games = new List<Game>(pairs.Count);
            for (int i = 0; i < pairs.Count; i++)
            {
                var slot = slots[i];
                var (home, away) = pairs[i];
                games.Add(new Game(home, away, slot));
            }

            //bye team console output
            if (byeTeam != null)
            {
                Console.WriteLine($"Team with bye due to odd number of teams: {byeTeam.Name} (Grade {byeTeam.Grade})");
            }

            return games;
        }
    }
}