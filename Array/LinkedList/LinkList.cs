using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            list.DeleteNode(5);
            Assert.AreEqual(list.Length, 4);
        }

        public class LinkedList
        {
            public class Node
            {
                public object dataNode;
                public Node next;
            }
            private Node firstNode;
            private Node lastNode;
            private int count;

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
                    count++;
                    LinkedList temp = new LinkedList();
                    for (int i = 0; i < count ; i++)
                    {
                        if (i == (position - 1)) 
                        {
                            temp.Add(dataNode);
                        }
                        else
                        {
                            temp.Add(firstNode.dataNode);
                            firstNode = firstNode.next;
                        }
                    }
                    firstNode = temp.firstNode;
                }
            }

            public void DeleteNode(int position)
            {
                LinkedList temp = new LinkedList();
                int index = 0;
                while(firstNode != null)
                {
                    index++;
                    if (index != position)
                        temp.Add(firstNode.dataNode);
                    firstNode = firstNode.next;
                }
                firstNode = temp.firstNode;
                count--;
            }
        }
    }
}
