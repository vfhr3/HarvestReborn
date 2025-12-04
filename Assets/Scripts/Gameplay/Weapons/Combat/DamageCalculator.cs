using Utils.Random;

namespace Gameplay.Weapons.Combat
{
    public interface IDamageCalculator
    {
        float Calculate(float baseDamage, float critChance, float critMult);
    }

    public class DamageCalculator : IDamageCalculator
    {
        private readonly IRandomProvider _randomProvider;

        public DamageCalculator(IRandomProvider randomProvider)
        {
            _randomProvider = randomProvider;
        }

        public float Calculate(float baseDamage, float critChance, float critMult)
        {
            var isCritical = _randomProvider.Value() < critChance;
            return isCritical ? baseDamage * critMult : baseDamage;
        }
    }
}