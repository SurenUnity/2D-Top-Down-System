using System;
using System.Collections.Generic;
using System.Linq;
using Injections;
using Models;
using UI.Controllers;
using UnityEngine;

namespace Controllers
{
    public class SystemController
    {
        public static DependencyContainer Container = new DependencyContainer();

        private List<object> _monoControllerses = new List<object>();
        public SystemController(Canvas canvas)
        {
            Container.BindScriptableObject<PlayerModel>("Player");
            Container.BindScriptableObject<EnemyModel>("Enemy");
            Container.BindScriptableObject<FruitModel>("Fruit");

            Container.Bind<WorldController>();
            Container.BindInstance(canvas);
            Container.Bind<EnemySpawnController>();
            Container.Bind<FruitSpawnController>();
            Container.Bind<InputController>();
            Container.Bind<PlayerController>();
            Container.Bind<PlayerUIController>();

            var monoControllers =  Container.GetBindedObjects().ToList().FindAll(c=>c is MonoControllers);

            _monoControllerses.AddRange(monoControllers);
        }

        public void Update(float deltaTime)
        {
            foreach (var mono in _monoControllerses)
            {
                var monoController = (MonoControllers) mono;

                monoController.Update(deltaTime);
            }
        }
    }
}
