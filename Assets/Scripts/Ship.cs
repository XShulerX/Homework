using UnityEngine;

namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation, IFire, IDamagable
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly IFire _fireImplementation;
        private readonly IDamagable _damageImplementation;
        public Ship(IMove moveImplementation,
            IRotation rotationImplementation,
            IFire fireImplementation,
            IDamagable damageImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _fireImplementation = fireImplementation;
            _damageImplementation = damageImplementation;
        }

        public float Speed => _moveImplementation.Speed;

        public void Move(float horizontal, float vertical)
        {
            _moveImplementation.Move(horizontal, vertical);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void Fire(Rigidbody2D bullet)
        {
            _fireImplementation.Fire(bullet);
        }

        public void TakeDamage()
        {
            _damageImplementation.TakeDamage();
        }

    }
}