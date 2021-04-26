using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class PlayerUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText = default;
        [SerializeField] private TextMeshProUGUI _coinText = default;

        [SerializeField] private TextMeshProUGUI _currentCoinText = default;
        [SerializeField] private TextMeshProUGUI _maxRecordText = default;

        [SerializeField] private GameObject _deadPanel = default;

        public void ChangeHealthText(int healthValue)
        {
            _healthText.text = $"Health: {healthValue}";
        }
        public void ChangeCoinText(int coinValue)
        {
            _coinText.text = $"Coin: {coinValue}";
        }

        public void OpenDeadPanel(int currentCoinValue, int maxRecordValue)
        {
            _deadPanel.SetActive(true);
            _currentCoinText.text = $"Current Coin: {currentCoinValue}";
            _maxRecordText.text = $"Record Coin: {maxRecordValue}";
        }
    }
}
