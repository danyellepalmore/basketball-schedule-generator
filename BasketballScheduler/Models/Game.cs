//Store references to allow reuse and save memory
using System;

namespace BasketballScheduler.Models
{
public class Game
{
    public Team Home { get; }
    public Team Away { get; }
    public TimeSlot Slot { get;private set; }

    //ensure references are not null
    public Game(Team home, Team away, TimeSlot slot)
    {
        Home = home ?? throw new ArgumentNullException(nameof(home));
        Away = away ?? throw new ArgumentNullException(nameof(away));
        Slot = slot ?? throw new ArgumentNullException(nameof(slot));
    }
    public void Reschedule(TimeSlot newSlot)
    {
        Slot = newSlot ?? throw new ArgumentNullException(nameof(newSlot));
    }
    //customize inhereted behavior
    public override string ToString()
    {
        return $"{Slot}: {Home} vs {Away}";
    }
}
}