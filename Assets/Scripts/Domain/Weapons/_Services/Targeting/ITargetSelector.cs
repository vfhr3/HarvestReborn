using System.Collections.Generic;
using UnityEngine;

namespace Domain.Weapons._Services.Targeting
{
    public interface ITargetSelector
    {
        Transform SelectTarget(Transform origin);
        List<Transform> SelectTargets(Transform origin, int maxCount);
    }
}