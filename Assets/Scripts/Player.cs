using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private Ship _ship;
        private float _horizontal;
        private float _vertical;

        private void Start()
        {
            _camera = Camera.main;
            var rigidbody = GetComponent<Rigidbody2D>();
            var moveTransform = new AccelerationMove(rigidbody, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            var fire = new FireBullet(_barrel, _force);
            var damagable = new Damagable(_hp);
            _ship = new Ship(moveTransform, rotation, fire, damagable);
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _ship.Fire(_bullet);
            }
        }

        private void FixedUpdate()
        {
            _ship.Move(_horizontal, _vertical);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _ship.TakeDamage();
        }
    }
}