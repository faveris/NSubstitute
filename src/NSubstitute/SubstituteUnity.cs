#if UNITY_5_3_OR_NEWER

using UnityEngine;
using System;
using System.Linq;

namespace NSubstitute
{
    public static partial class Substitute
    {
        public static T ForComponent<T>(GameObject gameObject)
            where T : class
        {
            return Substitute.For<T, MonoBehaviour>(
                (Type t, object[] arguments) =>
                {
                    Component proxy = gameObject.AddComponent(t);
                    Type[] types = arguments.Select(parameter => parameter.GetType()).ToArray();
                    proxy.GetType().GetConstructor(types).Invoke(proxy, arguments);
                    return proxy;
                });
        }

        public static T ForComponent<T>()
            where T : class
        {
            return ForComponent<T>(new GameObject());
        }
    }
}

#endif