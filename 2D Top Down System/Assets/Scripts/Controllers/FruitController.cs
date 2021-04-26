using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class FruitController
    {
        private FruitView _fruit;
        private FruitModel _fruitModel;

        public FruitController(Transform instanceTransform)
        {
            _fruit = Object.Instantiate(Resources.Load<FruitView>("Fruit"), instanceTransform.position, Quaternion.identity);
            _fruitModel = SystemController.Container.Injecting<FruitModel>();

            _fruit.onCollisionEnter += OnCollisionEnter;
        }

        private void OnCollisionEnter(Collider2D collider)
        {
            var iCoin = collider.gameObject.GetComponent<ICoin>();

            GetCoin(iCoin);
        }
        private void GetCoin(ICoin iCoin)
        {
            iCoin?.GetCoin(_fruitModel.coinValue);
        }

        private void Destroy()
        {
            _fruit.onCollisionEnter -= OnCollisionEnter;
        }
    }
}
