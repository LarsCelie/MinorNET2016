using System;
using Minor.Dag10.BinaryTree;

namespace Minor.Dag10.BinaryTree
{

    public class Branch<T> : MyBinaryTree<T> where T : IComparable
    {
        private T _item;
        public MyBinaryTree<T> LeftBranch { get; set; } = new Empty<T>();
        public MyBinaryTree<T> RightBranch { get; set; } = new Empty<T>();

        public Branch(T item)
        {
            this._item = item;
        }

        public override int Count
        {
            get
            {
                return LeftBranch.Count + RightBranch.Count + 1;
            }
        }

        public override int Depth
        {
            get
            {
                return 1 + Math.Max(LeftBranch.Depth, RightBranch.Depth);
            }
        }

        public override MyBinaryTree<T> Add(T item)
        {
            if (item.CompareTo(_item) < 0)
            {
                LeftBranch = LeftBranch.Add(item);
            }
            else if (item.CompareTo(_item) > 0)
            {
                RightBranch = RightBranch.Add(item);
            }

            return this;
        }

        public override bool Contains(T item)
        {
            return item.Equals(_item) || LeftBranch.Contains(item) || RightBranch.Contains(item);
        }
    }
}