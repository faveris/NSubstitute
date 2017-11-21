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
                    CallConstructor(proxy, arguments);
                    return proxy;
                });
        }

        public static T ForComponent<T>()
            where T : Component
        {
            return ForComponent<T>(new GameObject());
        }

        public static T ForScriptableObject<T>()
            where T : ScriptableObject
        {
            return For<T>(
                (type, arguments) =>
                {
                    ScriptableObject proxy = ScriptableObject.CreateInstance(type);
                    CallConstructor(proxy, arguments);
                    return proxy;
                });
        }

        private static void CallConstructor(object obj, object[] arguments)
        {
            Type[] types = arguments.Select(parameter => parameter.GetType()).ToArray();
            obj.GetType().GetConstructor(types).Invoke(obj, arguments);
        }
    }
}

#endif