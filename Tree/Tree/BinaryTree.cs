using System;
using System.Collections;
using System.Collections.Generic;
namespace Tree
{
    internal class BinaryTree<T>: IEnumerator<T[]>
    {
        public Node<T> root;
        private int count;

        public BinaryTree()
        {
            root = null;
            count = 0;
        }

        public T[] Current
        {
            get
            {
                return default(T[]);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (root == null)
                return false;
            else
                return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}