using System;
using System.Collections;
using System.Collections.Generic;
namespace Tree
{
    public class BinaryTree<T> :IEnumerable<T> where T : IComparable
    {
        public Node<T> root;

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

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorTree(root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class EnumeratorTree : IEnumerator<T>
        {
            private Node<T> root;

            public EnumeratorTree(Node<T> root)
            {
                this.root = root;
            }

            public T Current
            {
                get
                {
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
            }

            public bool MoveNext()
            {

                if (root == null)
                    return false;
                else return true;
                
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}