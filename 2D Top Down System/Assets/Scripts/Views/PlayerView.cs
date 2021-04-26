using System;
using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour, IDamage, ICoin
    {
        public event Action<int> takeDamage;
        public event Action<int> getCoin;

        public void TakeDamage(int damageValue)
        {
            takeDamage?.Invoke(damageValue);
        }

        public void GetCoin(int coinValue)
        {
            getCoin?.Invoke(coinValue);
        }
    }
}
