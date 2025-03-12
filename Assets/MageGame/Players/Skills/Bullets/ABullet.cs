using JetBrains.Annotations;
using MageGame.Utilities;
using UnityEngine;

namespace MageGame.Players.Skills.Bullets
{
    [RequireComponent(typeof(Damager))]
    public abstract class ABullet : MonoBehaviour
    {
        [CanBeNull] Damager _damager;
        protected Damager Damager => _damager ??= GetComponent<Damager>();
    }
}
