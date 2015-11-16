using System;
using System.Collections;
using System.Collections.Generic;
namespace Tree
{
    internal class BinaryTree<T> : IEnumerator<T> where T : IComparable
    {
        public Node<T> root;
        public Node<T>[] parent;

        public BinaryTree()
        {
            root = null;
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);
            if (root == null)
                root = newNode;
            else
            {
                var currentNode = root;
                bool added = false;
                while (added == false)
                {
                    if (-1 == value.CompareTo(currentNode.value)) //go left
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = newNode;
                            added = true;
                        }
                        else
                        {
                            currentNode = currentNode.left;
                        }
                    }
                    else
                    {
                        if (currentNode.right == null)
                        {
                            currentNode.right = newNode;
                            added = true;
                        }
                        else
                        {
                            currentNode = currentNode.right;
                        }
                    }
                }
            }
        }

        public T Current
        {
            get
            {
                if(MoveNext())
                    return root.value;
                else
                    throw new NotImplementedException();
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
            else if (root.left != null)
            {
                root = root.left;
            }
            else if (root.right != null)
            {
                root = root.right;
            }
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}