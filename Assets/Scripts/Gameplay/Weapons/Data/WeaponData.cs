using UnityEngine;

namespace Gameplay.Weapons.Data
{
    public abstract class WeaponData : ScriptableObject
    {
        [Header("Identity")] [SerializeField] private string weaponName;

        [SerializeField] private string description;

        [Header("Damage")] [SerializeField] private float damage;

        [SerializeField] private float criticalHitChance;
        [SerializeField] private float criticalHitMultiplier;

        [Header("Timing")] [SerializeField] private float baseCooldown;

        [SerializeField] private float cooldownRecoverRate;

        [Header("Physics")] [SerializeField] private float knockbackForce;

        [SerializeField] private float areaScale;

        public string WeaponName => weaponName;
        public string Description => description;
        public float Damage => damage;
        public float CriticalHitChance => criticalHitChance;
        public float CriticalHitMultiplier => criticalHitMultiplier;
        public float BaseCooldown => baseCooldown;
        public float CooldownRecoverRate => cooldownRecoverRate;
        public float KnockbackForce => knockbackForce;
        public float AreaScale => areaScale;
    }

    [CreateAssetMenu(fileName = "New Projectile Data", menuName = "Weapons/Data/Projectile")]
    public class ProjectileWeaponData : WeaponData
    {
        [Header("Projectile")] [SerializeField]
        private float range;

        [SerializeField] private float projectileSpeed;
        [SerializeField] private int pierceCount;

        public float Range => range;
        public float ProjectileSpeed => projectileSpeed;
        public int PierceCount => pierceCount;
    }

    [CreateAssetMenu(fileName = "Melee Weapon Data", menuName = "Weapons/Melee Weapon Data")]
    public class MeleeWeaponData : WeaponData
    {
        [Header("Melee")] [SerializeField] private int strikeCount;

        public int StrikeCount => strikeCount;
    }

    [CreateAssetMenu(fileName = "Melee Weapon Data", menuName = "Weapons/AoE Weapon Data")]
    public class AreaWeaponData : WeaponData
    {
        [Header("AoE")] [SerializeField] private float radius;

        [SerializeField] private float duration;
        [SerializeField] private float tickRate;
        [SerializeField] private bool isPersistent;

        public float Radius => radius;
        public float Duration => duration;
        public float TickRate => tickRate;
        public bool IsPersistent1 => isPersistent;
    }
}