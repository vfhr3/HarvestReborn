namespace Core.Models
{
    public interface IHealthSystem
    {
        bool IsDead { get; }
        int Current { get; }
        int Max { get; }
        void ApplyDamage(int damage);
        void Heal(int amount);
    }
}