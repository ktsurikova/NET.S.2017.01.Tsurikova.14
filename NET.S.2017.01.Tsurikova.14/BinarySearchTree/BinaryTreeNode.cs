using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    /// <summary>
    /// class that represents node for tree
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    internal class BinaryTreeNode<T>
    {
        /// <summary>
        /// value of node
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// reference to the left node
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// reference to the right node
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// default ctor
        /// </summary>
        public BinaryTreeNode() { }

        /// <summary>
        /// initializes a new instance of node with data
        /// </summary>
        /// <param name="data">data of node</param>
        public BinaryTreeNode(T data) : this(data, null, null) { }

        /// <summary>
        /// initializes a new instance of node with data and neighbors
        /// </summary>
        /// <param name="data">data of value</param>
        /// <param name="otherLeft">left node</param>
        /// <param name="otherRight">right node</param>
        public BinaryTreeNode(T data, BinaryTreeNode<T> otherLeft, BinaryTreeNode<T> otherRight)
        {
            Value = data;
            Left = otherLeft;
            Right = otherRight;
        }

    }
}
