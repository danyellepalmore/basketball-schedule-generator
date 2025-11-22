// See https://aka.ms/new-console-template for more information
<<<<<<< HEAD

//instantiate classes test
using BasketballScheduler.Models;

var teamA = new Team("Falcons", 6);
var teamB = new Team("Tigers", 6);
var slot = new TimeSlot(DateTime.Today.AddHours(9), 60, 1);
var game = new Game(teamA, teamB, slot);
Console.WriteLine(game);

=======
Console.WriteLine("Hello, World!");
>>>>>>> 9b1c43898d81ee80dfb7fae8e40414fdf0f20224
