using System;
using UnityEngine;

namespace Views
{
    public class FruitView : MonoBehaviour
    {
        public event Action<Collider2D> onCollisionEnter;

        private void OnTriggerEnter2D(Collider2D other)
        {
            onCollisionEnter?.Invoke(other);
        }
    }
}
