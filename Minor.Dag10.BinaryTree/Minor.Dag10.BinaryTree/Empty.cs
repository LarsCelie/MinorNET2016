using System;
using Minor.Dag10.BinaryTree;

namespace Minor.Dag10.BinaryTree
{

    public class Empty<T> : MyBinaryTree<T> where T : IComparable
    {
        public override int Count
        {
            get
            {
                return 0;
            }
        }

        public override int Depth
        {
            get
            {
                return 0;
            }
        }

        public override MyBinaryTree<T> Add(T item)
        {
            return new Branch<T>(item);
        }

        public override bool Contains(T item)
        {
            return false;
        }
    }
}