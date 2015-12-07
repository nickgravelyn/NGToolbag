using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityToolbag
{
    /// <summary>
    /// Pool class for component lists used in event system. Returns lists that automagically
    /// return to pool after <code>foreach</code> iteration ends. DO NOT use for other things!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ComponentListPool<T>
    {
        /// <summary>
        /// Automagically returning list
        /// </summary>
        class PoolList: List<T>, IEnumerable<T>
        {
            /// <summary>
            /// IEnumerator reimplementation. Cannot reuse built-in <code>List</code> implementation because
            /// it's a struct (whch in itself is an ugly anti-GC hack).
            /// This implementation returns list back to pool after iteration is finished (using Dispose)
            /// </summary>
            class Enumerator : IEnumerator<T>
            {
                private PoolList l;
                private int next;
                private T current;

                object IEnumerator.Current
                {
                    get { return current; }
                }

                public T Current
                {
                    get { return current; }
                }

                internal Enumerator(PoolList l)
                {
                    this.l = l;
                    next = 0;
                    current = default(T);
                }

                public void Reset()
                {
                    throw new NotImplementedException("ComponentListPool lists can only ever be iterated ONCE.");
                }

                public void Dispose()
                {
                    next = 0;
                    Return(l);
                }

                public bool MoveNext()
                {
                    if (next < l.Count)
                    {
                        current = l[next];
                        next++;
                    }
                    return next < l.Count;
                }
            }

            /// <summary>
            /// Enumerator instance. Normal lists create new instance with each <code>GetEnumerator</code> call, but since
            /// PoolList us intended to only be iterated once, we can get away with just creating it right away. And allocate
            /// no additional memory when used!
            /// </summary>
            private readonly Enumerator m_Enumerator;

            public PoolList()
            {
                m_Enumerator = new Enumerator(this);
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                return m_Enumerator;
            }

        }
        private static void Return(PoolList poolList)
        {
            poolList.Clear(); // this is not strictly required, but let's ensure we don't hoard refs to user objects
            s_Pool.Push(poolList);
        }

        private static readonly Stack<PoolList> s_Pool = new Stack<PoolList>();

        /// <summary>
        /// Get new list from pool, or create new one if pool is empty. DO NOT store the list you got here: it's only good
        /// for one <code>foreach</code> cycle.
        /// </summary>
        /// <returns></returns>
        public static List<T> Get()
        {
            if (s_Pool.Count == 0)
            {
                return new PoolList();
            }
            return s_Pool.Pop();
        } 
    }


}