using DG.Tweening;
using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class EnemyController
    {
        private EnemyView _enemy;
        private EnemyModel _enemyModel;

        public EnemyController(Transform instanceTransform)
        {
            _enemy = Object.Instantiate(Resources.Load<EnemyView>("Enemy"), instanceTransform.position, Quaternion.identity);
            _enemyModel = SystemController.Container.Injecting<EnemyModel>();

            _enemy.onCollisionEnter += OnCollisionEnter;

            Move();
        }

        private void OnCollisionEnter(Collider2D collider)
        {
            var iDamage = collider.gameObject.GetComponent<IDamage>();

            Attack(iDamage);
        }

        private void Move()
        {
            var randomTargetPosition = new Vector2(Random.Range(_enemyModel.minRange.x, _enemyModel.maxRange.x),
                Random.Range(_enemyModel.minRange.y, _enemyModel.maxRange.y));

            _enemy.transform.DOMove(randomTargetPosition, _enemyModel.speed).OnComplete(Move);
        }

        private void Attack(IDamage iDamage)
        {
            iDamage?.TakeDamage(_enemyModel.damage);
        }

        private void Destroy()
        {
            _enemy.onCollisionEnter -= OnCollisionEnter;
        }
    }
}
