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
            LinkedList list = new LinkedList();
            list.Add(15);
            Assert.AreEqual(list.Length, 1);
            list.Add("test");
            Assert.AreEqual(list.Length, 2);
            list.Add(23);
            list.Add("Razvan");
            Assert.AreEqual(list.Length, 4);
        }
        [TestMethod]
        public void InsertNodeToLinkedList()
        {
            LinkedList list = new LinkedList();
            list.Insert(15,1);
            Assert.AreEqual(list.Length, 1);
            list.Insert("test", 2);
            Assert.AreEqual(list.Length, 2);
            list.Add(234);
            list.Add("Razvan");
            list.Add("Andrei");
            list.Insert("INSERT", 4);
            Assert.AreEqual(list.Length, 6);
        }
        [TestMethod]
        public void DeleteNodeFromLinkedList()
        {
            LinkedList list = new LinkedList();
            list.Insert(15, 1);
            list.DeleteNode(1);
            Assert.AreEqual(list.Length, 0);
            list.Insert("test", 2);
            list.Add(234);
            list.Add("Razvan");
            list.Add("Andrei");
            list.Insert("INSERT", 4);
            list.DeleteNode(4);
            Assert.AreEqual(list.Length, 4);
        }
        [TestMethod]
        public void ReturnValueFromNode()
        {
            LinkedList list = new LinkedList();
            list.Insert(15, 1);
            Assert.AreEqual(list.ReturnElement(1), 15);
            list.Add("test");
            list.Add(234);
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
            LinkedList list = new LinkedList();
            list.Insert(15, 1);
            Assert.AreEqual(list.ReturnNode (1), 15);
            list.Add("test");
            list.Add(234);
            Assert.AreEqual("test", list.ReturnNode(2));
            list.Add("Razvan");
            list.Add("Andrei");
            list.Insert("INSERT", 4);
            Assert.AreEqual("INSERT", list.ReturnNode(4));
            Assert.AreEqual("Andrei", list.ReturnNode(6));
        }


        public class LinkedList:IEnumerable 
        {
            public class Node
            {
                public object dataNode;
                public Node next;
            }
            private Node firstNode;
            private Node lastNode;
            private int count;
            public IEnumerator GetEnumerator()
            {
                var tempNode = firstNode;
                while (tempNode != null)
                {
                    yield return tempNode.dataNode;
                    tempNode = tempNode.next;
                }
            }

            public object ReturnNode(int position)
            {
                int index = 0;
                var elements = GetEnumerator();
                while (elements.MoveNext()) 
                {
                    index++;
                    if (index == position)
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

            public void Add(object addDataNode)
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

            public void Insert(object dataNode, int position)
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
                object result;
                Node temp = firstNode;
                for (int i = 1; i < position; i++)
                    temp  = temp .next;
                result = temp.dataNode;
                return result;
            }
        }
    }
}
