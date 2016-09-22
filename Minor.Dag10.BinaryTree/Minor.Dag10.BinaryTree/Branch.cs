using System;
using System.Collections.Generic;
using Minor.Dag10.BinaryTree;

namespace Minor.Dag10.BinaryTree
{

    internal class Branch<T> : BinaryTree<T> where T : IComparable
    {
        private T _item;
        private BinaryTree<T> _leftbranch;
        private BinaryTree<T> _rightbranch;

        public Branch(T item)
        {
            _item = item;
            _leftbranch = BinaryTree<T>.Empty;
            _rightbranch = BinaryTree<T>.Empty;
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

        public override BinaryTree<T> Add(T item)
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

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _leftbranch)
            {
                yield return item;
            }
            yield return _item;
            foreach (T item in _rightbranch)
            {
                yield return item;
            }
        }
    }
}