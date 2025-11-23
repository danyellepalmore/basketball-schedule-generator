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
            
            // group teams by grade
            var groups = teams.GroupBy(t => t.Grade).OrderBy(g => g.Key); 

            // pairing logic
            var pairs = new List<(Team, Team)>();
            var byeTeams = new List<Team>();

            foreach (var group in groups)
            {
                var gradeTeams = group.ToList();
                //pair teams within grade 
                for (int i = 0; i < gradeTeams.Count - 1; i += 2)
                {
                    pairs.Add((gradeTeams[i], gradeTeams[i + 1]));
                }
                //handle odd team in grade
                if (gradeTeams.Count % 2 != 0)
                {
                    byeTeams.Add(gradeTeams.Last());
                }
            }

            //ensure enough slots
            if (pairs.Count > slots.Count)
                throw new InvalidOperationException("Not enough time slots for all games.");
            // index aligned mapping; alternate home and away teams
            var games = new List<Game>(pairs.Count);
            for (int i = 0; i < pairs.Count; i++)
            {
                var slot = slots[i];
                var (teamA, teamB) = pairs[i];
                if (i % 2 == 0)
                    games.Add(new Game(teamA, teamB, slot));
                else
                    games.Add(new Game(teamB, teamA, slot));
            }

            //bye team console output
            foreach (var team in byeTeams)
            {
                Console.WriteLine($"Team {team.Name} has a bye this round because there is no same grade opponent.");
            }

            return games;
        }
    }
}