#if UNITY_5_3_OR_NEWER

using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

namespace NSubstitute
{
    public static partial class Substitute
    {
        public static T ForComponent<T>(GameObject gameObject)
            where T : Component
        {
            return For<T>(
                (type, arguments) =>
                {
                    Component proxy = gameObject.AddComponent(type);
                    Type[] types = arguments.Select(parameter => parameter.GetType()).ToArray();
                    proxy.GetType().GetConstructor(types).Invoke(proxy, arguments);
                    return proxy;
                });
        }

        public static T ForComponent<T>()
            where T : Component
        {
            return ForComponent<T>(new GameObject());
        }
    }
}

#endif