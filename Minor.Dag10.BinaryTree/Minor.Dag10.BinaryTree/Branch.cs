using System;
using Minor.Dag10.BinaryTree;

namespace Minor.Dag10.BinaryTree
{

    internal class Branch<T> : MyBinaryTree<T> where T : IComparable
    {
        private T _item;
        private MyBinaryTree<T> _leftbranch;
        private MyBinaryTree<T> _rightbranch;

        public Branch(T item)
        {
            _item = item;
            _leftbranch = new Empty<T>();
            _rightbranch = new Empty<T>();
        }

        public override int Count
        {
            get
            {
                return _leftbranch.Count + _rightbranch.Count + 1;
            }
        }

        public override int Depth
        {
            get
            {
                return 1 + Math.Max(_leftbranch.Depth, _rightbranch.Depth);
            }
        }

        public override MyBinaryTree<T> Add(T item)
        {
            if (item.CompareTo(_item) < 0)
            {
                _leftbranch = _leftbranch.Add(item);
            }
            else if (item.CompareTo(_item) > 0)
            {
                _rightbranch = _rightbranch.Add(item);
            }

            return this;
        }

        public override bool Contains(T item)
        {
            int comparison = item.CompareTo(_item);
            if (comparison < 0)
            {
                return _leftbranch.Contains(item);
            }
            else if (comparison > 0)
            {
                return _rightbranch.Contains(item);
            }
            return true;
        }
    }
}