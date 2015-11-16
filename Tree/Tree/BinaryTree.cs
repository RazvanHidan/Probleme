using System;
using System.Collections;
using System.Collections.Generic;
namespace Tree
{
    internal class BinaryTree<T>: IEnumerator<T>where T :IComparable
    {
        public Node<T> root;
        private int count;

        public BinaryTree()
        {
            root = null;
            count = 0;
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);
            if (root == null)
                root = newNode;
            else
            {
                var curentNode = root;
                bool added = false;
                while (added == false)
                {
                    if (-1 == value.CompareTo(curentNode.value)) //go left
                    {
                        if (curentNode.left == null)
                        {
                            curentNode.left = newNode;
                            added = true;
                        }
                        else
                        {
                            curentNode = curentNode.left;
                        }
                    }
                    else
                    {
                        if (curentNode.right == null)
                        {
                            curentNode.right = newNode;
                            added = true;
                        }
                        else
                        {
                            curentNode = curentNode.right;
                        }
                    }
                }
            }   
        }
        


        public T Current
        {
            get
            {
                if(!MoveNext())
                    return default(T);
                else
                    return root.value;
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
            {
                if (root.left != null)
                    return true;
                if (root.right != null)
                    return true;
            }
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}