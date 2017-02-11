using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityToolbag
{
    public static class EventExtensions
    {
        /// <summary>
        /// Enumerates over all components of a gameobject. DO NOT store the result of this method. It is
        /// only safe to use directly in <code>foreach</code> statement.
        /// </summary>
        public static IEnumerable<T> EnumerateComponents<T>(this GameObject gameObject)
        {
            var list = ComponentListPool<T>.Get();
            gameObject.GetComponents(list);
            return list;
        }
        /// <summary>
        /// Enumerates over all components of a gameobject and its children. DO NOT store the result of this method. It is
        /// only safe to use directly in <code>foreach</code> statement.
        /// </summary>
        public static IEnumerable<T> EnumerateComponentsInChildren<T>(this GameObject gameObject)
        {
            var list = ComponentListPool<T>.Get();
            gameObject.GetComponentsInChildren(list);
            return list;
        }
        /// <summary>
        /// Enumerates over all components of a gameobject and its parents. DO NOT store the result of this method. It is
        /// only safe to use directly in <code>foreach</code> statement.
        /// </summary>
        public static IEnumerable<T> EnumerateComponentsInParent<T>(this GameObject gameObject, bool withInactive = false)
        {
            var list = ComponentListPool<T>.Get();
            gameObject.GetComponentsInParent(withInactive, list);
            return list;
        }

        /// <summary>
        /// Calls a delegate for all components of a gameobject that have specified type.
        /// </summary>
        public static void Send<T>(this GameObject gameObject, Action<T> action)
        {
            foreach (var c in gameObject.EnumerateComponents<T>())
            {
                action(c);
            }
        }
        /// <summary>
        /// Calls a delegate for all components of a gameobject that have specified type.
        /// </summary>
        public static void Send<T, TArg1>(this GameObject gameObject, Action<T, TArg1> action, TArg1 arg1)
        {
            foreach (var c in gameObject.EnumerateComponents<T>())
            {
                action(c, arg1);
            }
        }
        /// <summary>
        /// Calls a delegate for all components of a gameobject that have specified type.
        /// </summary>
        public static void Send<T, TArg1, TArg2>(this GameObject gameObject, Action<T, TArg1, TArg2> action, TArg1 arg1, TArg2 arg2)
        {
            foreach (var c in gameObject.EnumerateComponents<T>())
            {
                action(c, arg1, arg2);
            }
        }
        /// <summary>
        /// Calls a delegate for all components of a gameobject that have specified type.
        /// </summary>
        public static void Send<T, TArg1, TArg2, TArg3>(this GameObject gameObject, Action<T, TArg1, TArg2, TArg3> action, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            foreach (var c in gameObject.EnumerateComponents<T>())
            {
                action(c, arg1, arg2, arg3);
            }
        }

        /// <summary>
        /// Calls a delegate for all components of a gameobject, or its children, that have specified type.
        /// </summary>
        public static void SendToChildren<T>(this GameObject gameObject, Action<T> action)
        {
            foreach (var c in gameObject.EnumerateComponentsInChildren<T>())
            {
                action(c);
            }
        }
        /// <summary>
        /// Calls a delegate for all components of a gameobject, or its children, that have specified type.
        /// </summary>
        public static void SendToChildren<T, TArg1>(this GameObject gameObject, Action<T, TArg1> action, TArg1 arg1)
        {
            foreach (var c in gameObject.EnumerateComponentsInChildren<T>())
            {
                action(c, arg1);
            }
        }
        /// <summary>
        /// Calls a delegate for all components of a gameobject, or its children, that have specified type.
        /// </summary>
        public static void SendToChildren<T, TArg1, TArg2>(this GameObject gameObject, Action<T, TArg1, TArg2> action, TArg1 arg1, TArg2 arg2)
        {
            foreach (var c in gameObject.EnumerateComponentsInChildren<T>())
            {
                action(c, arg1, arg2);
            }
        }
        /// <summary>
        /// Calls a delegate for all components of a gameobject, or its children, that have specified type.
        /// </summary>
        public static void SendToChildren<T, TArg1, TArg2, TArg3>(this GameObject gameObject, Action<T, TArg1, TArg2, TArg3> action, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            foreach (var c in gameObject.EnumerateComponentsInChildren<T>())
            {
                action(c, arg1, arg2, arg3);
            }
        }

        /// <summary>
        /// Calls a delegate for all components of a gameobject, or its parents, that have specified type.
        /// </summary>
        public static void SendToParents<T>(this GameObject gameObject, Action<T> action)
        {
            foreach (var c in gameObject.EnumerateComponentsInParent<T>())
            {
                action(c);
            }
        }
        /// <summary>
        /// Calls a delegate for all components of a gameobject, or its parents, that have specified type.
        /// </summary>
        public static void SendToParents<T, TArg1>(this GameObject gameObject, Action<T, TArg1> action, TArg1 arg1)
        {
            foreach (var c in gameObject.EnumerateComponentsInParent<T>())
            {
                action(c, arg1);
            }
        }
        /// <summary>
        /// Calls a delegate for all components of a gameobject, or its parents, that have specified type.
        /// </summary>
        public static void SendToParents<T, TArg1, TArg2>(this GameObject gameObject, Action<T, TArg1, TArg2> action, TArg1 arg1, TArg2 arg2)
        {
            foreach (var c in gameObject.EnumerateComponentsInParent<T>())
            {
                action(c, arg1, arg2);
            }
        }
        /// <summary>
        /// Calls a delegate for all components of a gameobject, or its parents, that have specified type.
        /// </summary>
        public static void SendToParents<T, TArg1, TArg2, TArg3>(this GameObject gameObject, Action<T, TArg1, TArg2, TArg3> action, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            foreach (var c in gameObject.EnumerateComponentsInParent<T>())
            {
                action(c, arg1, arg2, arg3);
            }
        }
    }
}