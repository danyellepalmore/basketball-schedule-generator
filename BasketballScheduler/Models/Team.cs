// Time Complexity O(1) | 
using System;

namespace BasketballScheduler.Models
{
    public class Team
    {
        //Immutable properties fot data integrity
        public string Name { get; }
        public int Grade { get; }

        // Constructor validation
        public Team(string name, int grade)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Team name cannot be null or empty.", nameof(name));
            }
            if (grade <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be a positive integer.");
            }

            // Assigning values to properties
            Name = name.Trim();
            Grade = grade;
        }
        public override string ToString() => $"{Name} (Grade {Grade})";
    }
}