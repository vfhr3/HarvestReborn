using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Weapons.Targeting
{
    public interface ITargetSelector
    {
        Transform SelectTarget(Transform origin);
        List<Transform> SelectTargets(Transform origin, int maxCount);
    }

    public class NearestEnemySelector : ITargetSelector
    {
        private readonly string _enemyTag;

        public NearestEnemySelector(string enemyTag = "Enemy")
        {
            _enemyTag = enemyTag;
        }

        public Transform SelectTarget(Transform origin)
        {
            var enemies = GameObject.FindGameObjectsWithTag(_enemyTag);

            Transform nearest = null;

            var minDistance = float.MaxValue;

            foreach (var enemy in enemies)
            {
                var distance = Vector3.Distance(origin.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = enemy.transform;
                }
            }

            return nearest;
        }

        public List<Transform> SelectTargets(Transform origin, int maxCount)
        {
            var enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
            var targets = new List<Transform>();

            Array.Sort(enemies, (a, b) =>
            {
                var distA = Vector3.Distance(origin.position, a.transform.position);
                var distB = Vector3.Distance(origin.position, b.transform.position);
                return distA.CompareTo(distB);
            });

            for (var i = 0; i < Mathf.Min(maxCount, enemies.Length); i++) targets.Add(enemies[i].transform);

            return targets;
        }
    }
}