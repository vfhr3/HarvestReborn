using Domain.Events;

namespace Events.Level
{
    public class LevelUpEvent : IEventData
    {
        public LevelUpEvent(int oldLevel, int newLevel)
        {
            OldLevel = oldLevel;
            NewLevel = newLevel;
        }

        public int NewLevel { get; }
        public int OldLevel { get; }
    }
}