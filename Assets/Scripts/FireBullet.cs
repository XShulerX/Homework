using UnityEngine;

namespace Asteroids
{
    internal sealed class FireBullet : IFire
    {
        private readonly Transform _barrel;
        private readonly float _force;

        public FireBullet(Transform barrel, float force)
        {
            _barrel = barrel;
            _force = force;
        }

        public void Fire(Rigidbody2D bullet)
        {
            var temAmmunition = Object.Instantiate(bullet, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
        }
    }
}