using UnityEngine;
using Asteroids.Object_Pool;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);
        }
    }
}