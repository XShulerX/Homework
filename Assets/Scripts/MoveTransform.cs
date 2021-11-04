using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Rigidbody2D _rigidbody;
        private Vector2 _move;

        public float Speed { get; protected set; }

        public MoveTransform(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical)
        {
            _move.Set(_rigidbody.transform.up.x*horizontal*Speed,
            _rigidbody.transform.up.y*vertical*Speed);
            _rigidbody.velocity = _move;
        }
    }
}