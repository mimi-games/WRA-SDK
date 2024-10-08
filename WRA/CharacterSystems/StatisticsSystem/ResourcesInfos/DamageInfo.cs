using UnityEngine;

namespace WRA.CharacterSystems.StatisticsSystem.ResourcesInfos
{
    public class DamageInfo : ResourcesChangedBase
    {
        public float PhysicalDamage;
        public float FireDamage;
        public float IceDamage;
        public bool CriticalHit;
        public bool CanBeReflected;
        
        public float DealtDamage = 0;
        public float ScalingDamage = 1;

        public bool containsHitPosition;

        public Vector3 HitedPosition
        {
            get
            {
                return hitedPosition;
            }

            set
            {
                hitedPosition = value;
                containsHitPosition = true;
            }
        }

        private Vector3 hitedPosition;
    }
}