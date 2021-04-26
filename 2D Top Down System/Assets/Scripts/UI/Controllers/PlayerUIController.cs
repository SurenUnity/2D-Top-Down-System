using Controllers;
using Models;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class PlayerUIController
    {
        private PlayerUIView _playerUI;
        private PlayerModel _playerModel;
        private Canvas _canvas;

        public PlayerUIController()
        {
            _playerModel = SystemController.Container.Injecting<PlayerModel>();
            _canvas = SystemController.Container.Injecting<Canvas>();
            _playerUI = Object.Instantiate(Resources.Load<PlayerUIView>("PlayerWindow"), _canvas.transform);

            ChangeHealthText(_playerModel.health);
            ChangeCoinText(_playerModel.coin);

            _playerModel.healthChange += ChangeHealthText;
            _playerModel.coinChange += ChangeCoinText;
            _playerModel.die += Dead;
        }

        private void ChangeHealthText(int healthValue)
        {
            _playerUI.ChangeHealthText(healthValue);
        }

        private void ChangeCoinText(int coinValue)
        {
            _playerUI.ChangeCoinText(coinValue);
        }

        private void Dead()
        {
            _playerUI.OpenDeadPanel(_playerModel.coin, _playerModel.maxRecordCoin);
            _playerModel.healthChange -= ChangeHealthText;
            _playerModel.coinChange -= ChangeCoinText;
        }
    }
}
