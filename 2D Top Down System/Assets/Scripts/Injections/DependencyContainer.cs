using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Injections
{
    public sealed class DependencyContainer
    {
        private readonly HashSet<object> bindedObjects = new HashSet<object>();

        public TClass Bind<TClass>() where TClass : class, new()
        {
            var currentObject = new TClass();

            bindedObjects.Add(currentObject);

            return currentObject;
        }

        public void BindInstance(object instance)
        {
            bindedObjects.Add(instance);
        }

        public TClass BindScriptableObject<TClass>(string name) where TClass : ScriptableObject, new()
        {
            var currentObject = Object.Instantiate(Resources.Load<ScriptableObject>(name));

            bindedObjects.Add(currentObject);

            return (TClass) currentObject;
        }

        public TClass Injecting<TClass>() where TClass : class
        {
            var result = (TClass)bindedObjects.FirstOrDefault(t => t is TClass);

            return result;
        }

        public HashSet<object> GetBindedObjects()
        {
            return bindedObjects;
        }
    }
}
