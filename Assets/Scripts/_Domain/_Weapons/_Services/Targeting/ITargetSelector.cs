using System.Collections.Generic;
using UnityEngine;

namespace _Infrastructure.Weapons.Targeting
{
    public interface ITargetSelector
    {
        Transform SelectTarget(Transform origin);
        List<Transform> SelectTargets(Transform origin, int maxCount);
    }
}