using System.Collections.Generic;

namespace Controllers
{
    public class FruitSpawnController
    {
        private List<FruitController> _fruitControllers = new List<FruitController>();

        private WorldController _worldController;

        public FruitSpawnController()
        {
            _worldController = SystemController.Container.Injecting<WorldController>();

            for (int i = 0; i < _worldController.GetEnemyTransforms().Length; i++)
            {
                _fruitControllers.Add(new FruitController(_worldController.GetFruitTransforms()[i]));
            }
        }
    }
}
