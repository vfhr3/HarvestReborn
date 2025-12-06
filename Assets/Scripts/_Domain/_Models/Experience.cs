using System;

namespace Core.Models
{
    public class Experience
    {
        private int _current;
        private int _level;

        public Experience(int startingLevel = 0)
        {
            _level = startingLevel;
        }

        public int Current => _current;
        public int Level => _level;
        public int RequiredForNextLevel => CalculateRequiredExperience(_level + 1);

        public float Progress => (float)_current / RequiredForNextLevel;

        private int CalculateRequiredExperience(int targetLevel)
        {
            const int baseXp = 100;
            const float exponent = 1.20f;

            return (int)Math.Pow(targetLevel, exponent) * baseXp;
        }

        public bool CanLevelUp()
        {
            return _current >= RequiredForNextLevel;
        }

        public void AddExperience(int amount)
        {
            if (amount < 0) throw new ArgumentException(nameof(amount));

            _current += amount;
        }

        public bool TryLevelUp()
        {
            if (!CanLevelUp()) return false;

            _current -= RequiredForNextLevel;
            _level++;
            return true;
        }
    }
}