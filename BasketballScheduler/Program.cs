// See https://aka.ms/new-console-template for more information

//instantiate classes test
using BasketballScheduler.Models;

var teamA = new Team("Falcons", 6);
var teamB = new Team("Tigers", 6);
var slot = new TimeSlot(DateTime.Today.AddHours(9), 60, 1);
var game = new Game(teamA, teamB, slot);
Console.WriteLine(game);

