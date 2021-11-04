using UnityEngine;

namespace Asteroids
{
    internal class Damagable : IDamagable
    {
        public float HealthPoints { get; protected set; }

        public Damagable(float healthPoints)
        {
            HealthPoints = healthPoints;
        }

        public void TakeDamage()
        {
            if (HealthPoints <= 0)
            {
                
            }
            else
            {
                HealthPoints--;
            }
        }
    }
}