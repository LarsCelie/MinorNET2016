using System;

namespace Minor.Dag10.BinaryTree
{
    public abstract class MyBinaryTree<T> where T : IComparable
    {
        public static MyBinaryTree<T> Empty = new Empty<T>();

        public abstract int Depth { get; }

        public abstract int Count { get; }

        public abstract MyBinaryTree<T> Add(T item);

        public abstract bool Contains(T item);
    }

}