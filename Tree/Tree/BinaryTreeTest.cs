using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace Tree
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void BinaryTreeIsNull()
        {
            var tree = new BinaryTree<int>();
            tree.root.ShouldBeNull();
        }

        [TestMethod]
        public void BinaryTreeAddRoot()
        {
            var tree = new BinaryTree<int>();
            tree.Add(4);
            tree.ShouldContain(4);
        }

        [TestMethod]
        public void BinaryTreeAddLeaf()
        {
            var tree = new BinaryTree<int>();
            tree.Add(4);
            tree.Add(1);
            tree.Add(10);
            tree.ShouldContain(1);
            tree.ShouldContain(4);
            tree.ShouldContain(10);
        }
    }
}
