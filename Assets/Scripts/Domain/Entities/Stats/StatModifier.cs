namespace Domain.Entities.Stats
{
    public class StatModifier
    {
        private readonly ModifierType _modifierType;
        private readonly StatType _statType;
        public float Value;

        public StatModifier(StatType statType, ModifierType modifierType, float value)
        {
            _statType = statType;
            _modifierType = modifierType;
            Value = value;
        }
    }
}