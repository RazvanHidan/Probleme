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

        public class LinkedList
        {
            public class Node
            {
                public object dataNode;
                public Node next;
            }
            public Node firstNode;
            public Node lastNode;
            public int count;
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
        }
    }
}
