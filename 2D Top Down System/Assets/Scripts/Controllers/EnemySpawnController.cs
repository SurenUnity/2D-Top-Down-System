using System.Collections.Generic;

namespace Controllers
{
    public class EnemySpawnController
    {
        private List<EnemyController> _enemyControllers = new List<EnemyController>();

        private WorldController _worldController;

        public EnemySpawnController()
        {
            _worldController = SystemController.Container.Injecting<WorldController>();

            for (int i = 0; i < _worldController.GetEnemyTransforms().Length; i++)
            {
                _enemyControllers.Add(new EnemyController(_worldController.GetEnemyTransforms()[i]));
            }
        }
    }
}
