using Domain.Events;

namespace Events.Level
{
    public class ExperienceGainEvent : IEventData
    {
        public ExperienceGainEvent(int amount, int totalExperience)
        {
            Amount = amount;
            TotalExperience = totalExperience;
        }

        public int Amount { get; }
        public int TotalExperience { get; }
        
        
    }
}