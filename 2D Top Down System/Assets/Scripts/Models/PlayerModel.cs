using System;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "Player", menuName = "CharacterModels/Player", order = 0)]
    public class PlayerModel : ScriptableObject
    {
        public event Action<int> healthChange;
        public event Action<int> coinChange;
        public event Action die;

        public float speed;
        public int health;
        public int coin;

        public int maxRecordCoin
        {
            get => PlayerPrefs.GetInt("RecordCoin");
            set
            {
                if (coin > PlayerPrefs.GetInt("RecordCoin"))
                {
                    PlayerPrefs.SetInt("RecordCoin", coin);
                }
            }
        }

        public void TakeDamage(int damageValue)
        {
            health -= damageValue;

            healthChange?.Invoke(health);

            if (health <= 0)
            {
                health = 0;
                Die();
            }
        }

        public void GetCoin(int coinValue)
        {
            coin += coinValue;
            coinChange?.Invoke(coin);
        }

        private void Die()
        {
            maxRecordCoin = coin;
            die?.Invoke();
        }
    }
}
