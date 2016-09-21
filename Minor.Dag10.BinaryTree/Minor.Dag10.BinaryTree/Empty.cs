using System;
using System.Collections.Generic;
using Minor.Dag10.BinaryTree;

namespace Minor.Dag10.BinaryTree
{

    internal class Empty<T> : MyBinaryTree<T> where T : IComparable
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

        public override IEnumerator<T> GetEnumerator()
        {
            yield break;
        }
    }
}