using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace LinkedList
{
    [TestClass]
    public class LinkList
    {
        [TestMethod]
        public void AddNodeToLinkedList() 
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("15");
            Assert.AreEqual(list.Length, 1);
            list.Add("test");
            Assert.AreEqual(list.Length, 2);
            list.Add("23");
            list.Add("Razvan");
            Assert.AreEqual(list.Length, 4);
        }
        [TestMethod]
        public void InsertNodeToLinkedList()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Insert("15",1);
            Assert.AreEqual(list.Length, 1);
            list.Insert("test", 2);
            Assert.AreEqual(list.Length, 2);
            list.Add("234");
            list.Add("Razvan");
            list.Add("Andrei");
            list.Insert("INSERT", 4);
            Assert.AreEqual(list.Length, 6);
        }
        [TestMethod]
        public void DeleteNodeFromLinkedList()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Insert("15", 1);
            list.DeleteNode(1);
            Assert.AreEqual(list.Length, 0);
            list.Insert("test", 2);
            list.Add("234");
            list.Add("Razvan");
            list.Add("Andrei");
            list.Insert("INSERT", 4);
            list.DeleteNode(4);
            Assert.AreEqual(list.Length, 4);
        }
        [TestMethod]
        public void ReturnValueFromNode()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Insert("15", 1);
            Assert.AreEqual("15",list.ReturnElement(1));
            list.Add("test");
            list.Add("234");
            Assert.AreEqual("test", list.ReturnElement(2));
            list.Add("Razvan");
            list.Add("Andrei");
            list.Insert("INSERT", 4);
            Assert.AreEqual("INSERT",list .ReturnElement(4));
            Assert.AreEqual("Andrei", list.ReturnElement(6));
        }
        [TestMethod]
        public void IEnumerable_LinkList_RetrunNode()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Insert("15", 1);
            Assert.AreEqual("15",list.ReturnNode (1));
            list.Add("test");
            list.Add("List");
            Assert.AreEqual("test", list.ReturnNode(2));
            list.Add("Razvan");
            list.Add("Andrei");
            list.Insert("INSERT", 4);
            Assert.AreEqual("INSERT", list.ReturnNode(4));
            Assert.AreEqual("Andrei", list.ReturnNode(6));
        }
        [TestMethod]
        public void List_GenericType()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Insert(15, 1);
            Assert.AreEqual(list.ReturnNode(1),15);
            list.Add(20);
            list.Add(999);
            Assert.AreEqual(list.ReturnNode(2),20);
            list.Add(57);
            list.Add(657);
            list.Insert(44, 4);
            Assert.AreEqual(list.ReturnNode(4),44);
            Assert.AreEqual(list.ReturnNode(6),657);
        }
        public class ListEnumerator<T>: IEnumerator
        {
            public LinkedList<T> element;
            public int index;
            private T current;

            public ListEnumerator(LinkedList<T> element)
            {
                this.element = element;
                index = -1;
            }
            object IEnumerator.Current
            {
                get
                {
                    return current;
                }
            }

            public bool MoveNext()
            {
                if (element.firstNode != null) 
                {
                    current = (T)element.ReturnElement(index + 2);
                    element.firstNode = element.firstNode.next;
                    return true;
                } 
                else return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }

        public class LinkedList<T>:IEnumerable 
        {
            public class Node
            {
                public T dataNode;
                public Node next;
            }
            public Node firstNode;
            public Node lastNode;
            private int count;
            public IEnumerator GetEnumerator()
            {
                LinkedList<T> temp = new LinkedList<T>();
                temp.firstNode = firstNode;
                return new ListEnumerator<T>(temp);
            }

            public object ReturnNode(int position)
            {
                int index = 0;
                var elements = GetEnumerator();
                while (elements.MoveNext()) 
                {
                    if (index++ == (position-1))
                    {
                        return elements.Current;
                    }
                }
                return null; 
            }

            public int Length
            {
                get
                {
                    return count;
                }
            }

            public LinkedList()
            {
                firstNode = null;
                count = 0;
            }

            public void Add(T addDataNode)
            {
                count++;
                Node node = new Node();
                node.dataNode = addDataNode;
                if(firstNode == null)
                {
                    firstNode = node;
                }
                else
                {
                    lastNode.next = node;
                }
                lastNode = node;
            }

            public void Insert(T dataNode, int position)
            {
                if ((firstNode == null) || (count == position - 1)) 
                    Add(dataNode);
                else
                {
                    Node newNode = new Node()
                    {
                        dataNode = dataNode
                    };
                    var tempNode = firstNode;
                    int index = 0;
                    while (tempNode != null)
                    {
                        index++;
                        if (index == (position-1))
                        {
                            newNode.next = tempNode.next;
                            tempNode.next = newNode;
                            break;
                        }
                        tempNode = tempNode.next;
                    }
                    count++;
                }
            }

            public void DeleteNode(int position)
            {
                var tempNode = firstNode;
                int index = 0;
                while(tempNode  != null)
                {
                    index++;
                    if (index == (position - 1))
                    {
                        tempNode.next = tempNode.next.next;
                    }

                    tempNode = tempNode.next;
                }
                count--;
            }

            public object ReturnElement(int position)
            {
                T result;
                Node temp = firstNode;
                for (int i = 1; i < position; i++)
                    temp  = temp .next;
                result = temp.dataNode;
                return result;
            }
        }
    }
}
