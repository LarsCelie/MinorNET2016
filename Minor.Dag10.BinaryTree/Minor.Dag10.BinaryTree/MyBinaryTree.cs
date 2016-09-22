using System;
using System.Collections;
using System.Collections.Generic;

namespace Minor.Dag10.BinaryTree
{
    public abstract class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        public static BinaryTree<T> Empty = new Empty<T>();

        public abstract int Depth { get; }

        public abstract int Count { get; }

        public abstract BinaryTree<T> Add(T item);

        public abstract bool Contains(T item);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                int count = -1;
                IEnumerator<T> enumerator = GetEnumerator();
                while (enumerator.MoveNext())
                {
                    count++;
                    if (count == index)
                    {
                        return enumerator.Current;
                    }
                }

                // nothing found
                throw new IndexOutOfRangeException();
            }
        }
    }

}