using UnityEngine;
using Views;

namespace Controllers
{
    public class WorldController
    {
        private WorldView _world;

        public WorldController()
        {
            _world = Object.Instantiate(Resources.Load<WorldView>("World"));
        }

        public Transform[] GetEnemyTransforms()
        {
            return _world.enemyPosition;
        }

        public Transform[] GetFruitTransforms()
        {
            return _world.fruitPosition;
        }
    }
}
