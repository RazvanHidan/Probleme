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
            return new EnumeratorTree(root); ;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class EnumeratorTree : IEnumerator<T>
        {
            private Node<T> root;
            private Node<T>[] parent;
            private Node<T> current;
            
            private int count;

            public EnumeratorTree(Node<T> root)
            {
                this.root = root;
                count = 0;
                current = null;
            }

            public void AddParent(Node<T> value)
            {
                count++;
                Array.Resize(ref parent, count);
                parent[count-1] = value;
            }

            public T Current
            {
                get
                {
                    return current.value;
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
                if (current == null)
                {
                    current = root;
                    AddParent(current);
                }
                else if (current.left != null)
                {
                    current = current.left;
                    AddParent(current);
                }
                else if (current.right != null)
                {
                    current = current.right;
                    AddParent(current);
                }
                else
                {
                    Node<T> last = current;
                    do
                    {
                        count--;
                        if (count == -1)
                            return false;
                        Array.Resize(ref parent, count - 1);
                        last = current;
                        current = parent[count];
                    } while (current.right == null||current.right==last);
                    current = current.right;
                    AddParent(current);
                }
                return true;
            }

            public void Reset()
            {    
            }
        }
    }
}