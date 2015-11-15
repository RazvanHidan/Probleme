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
            tree.Current.ShouldBeNull();
        }
    }
}
