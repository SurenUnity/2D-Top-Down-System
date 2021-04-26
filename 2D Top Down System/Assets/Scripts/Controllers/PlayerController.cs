using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class PlayerController : MonoControllers
    {
        private EnemyController _enemyController;
        private InputController _inputController;

        private PlayerModel _playerModel;
        private PlayerView _player;

        private Vector3 _targetPosition;

        public PlayerController()
        {
            _player = Object.Instantiate(Resources.Load<PlayerView>("Player"));
            _playerModel = SystemController.Container.Injecting<PlayerModel>();

            _targetPosition = _player.transform.position;

            _playerModel.die += Die;
            _player.takeDamage += TakeDamage;
            _player.getCoin += GetCoin;

            _inputController = SystemController.Container.Injecting<InputController>();
            _inputController.mouseClickPosition += SetMovePosition;
        }

        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {
            if(_player == null) return;
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _targetPosition,
                deltaTime * _playerModel.speed);
        }

        private void TakeDamage(int damageValue)
        {
            _playerModel.TakeDamage(damageValue);
        }

        private void GetCoin(int coinValue)
        {
            _playerModel.GetCoin(coinValue);
        }

        private void SetMovePosition(Vector3 targetPosition)
        {
            var correctTargetPosition = new Vector3(targetPosition.x, targetPosition.y, 0);
            _targetPosition = correctTargetPosition;
        }

        private void Die()
        {
            _player.takeDamage -= TakeDamage;
            _inputController.mouseClickPosition -= SetMovePosition;
            _playerModel.die -= Die;
            _player.getCoin -= GetCoin;

            Object.Destroy(_player.gameObject);
        }
    }
}
