using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Injections
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {

    }
}
