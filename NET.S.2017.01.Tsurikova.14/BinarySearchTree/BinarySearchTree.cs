using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    /// <summary>
    /// binary search tree collection
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public class BinarySearchTree<T> : ICollection<T>
    {
        #region fields

        private BinaryTreeNode<T> root;
        private IComparer<T> comparer;

        #endregion

        #region ctors

        /// <summary>
        /// initializes a new instance of tree with default comparison
        /// </summary>
        public BinarySearchTree()
        {
            root = null;
            if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)) ||
                typeof(IComparable).IsAssignableFrom(typeof(T)))
                comparer = Comparer<T>.Default;
            else throw new ArgumentException("type doesn't implement interface IComparable or IComparable<T>");
        }

        /// <summary>
        /// initializes a new instance of tree with otherComparer
        /// </summary>
        /// <param name="otherComparer">comparer</param>
        /// <exception cref="ArgumentNullException">throws when comparer is null</exception>
        public BinarySearchTree(IComparer<T> otherComparer)
        {
            if (ReferenceEquals(otherComparer, null))
                throw new ArgumentNullException($"{nameof(otherComparer)} is null");
            root = null;
            comparer = otherComparer;
        }

        /// <summary>
        /// initializes a new instance of tree with otherComparer
        /// </summary>
        /// <param name="otherComparer">comparer</param>
        /// <exception cref="ArgumentNullException">throws when comparer is null</exception>
        public BinarySearchTree(Comparison<T> otherComparer)
        {
            if (ReferenceEquals(otherComparer, null))
                throw new ArgumentNullException($"{nameof(otherComparer)} is null");
            root = null;
            comparer = Comparer<T>.Create(otherComparer);
        }

        #endregion

        /// <summary>
        /// define whether tree contains data
        /// </summary>
        /// <param name="data">data to be checked</param>
        /// <returns>true if contains, otherwise false</returns>
        /// <exception cref="ArgumentNullException">thrown when data is null</exception>
        public bool Contains(T data)
        {
            if (ReferenceEquals(data, null)) throw new ArgumentNullException($"{nameof(data)} is null");
            BinaryTreeNode<T> current = root;
            int result;
            while (current != null)
            {
                result = comparer.Compare(current.Value, data);
                if (result == 0)
                    return true;
                else if (result > 0)
                    current = current.Left;
                else if (result < 0)
                    current = current.Right;
            }

            return false;
        }

        #region Add

        /// <summary>
        /// add data in tree
        /// </summary>
        /// <param name="data">data to be added</param>
        /// <exception cref="ArgumentNullException">throws when data is null</exception>
        public void Add(T data)
        {
            if (ReferenceEquals(data, null)) throw new ArgumentNullException($"{nameof(data)} is null");

            BinaryTreeNode<T> n = new BinaryTreeNode<T>(data);
            int result;

            BinaryTreeNode<T> current = root, parent = null;
            while (current != null)
            {
                result = comparer.Compare(current.Value, data);
                if (result == 0)
                    return;
                else if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }
            Count++;
            if (parent == null)
                root = n;
            else
            {
                result = comparer.Compare(parent.Value, data);
                if (result > 0)
                    parent.Left = n;
                else
                    parent.Right = n;
            }
        }

        #endregion

        #region Remove

        /// <summary>
        /// remove data from tree
        /// </summary>
        /// <param name="data">data to be removed</param>
        /// <returns>true if data is sucessfully removed, otherwise false</returns>
        /// <exception cref="ArgumentNullException">throws when data is null</exception>
        public bool Remove(T data)
        {
            if (ReferenceEquals(data, null))
                throw new ArgumentNullException($"{nameof(data)} is null");

            // first make sure there exist some items in this tree
            if (root == null)
                return false;       // no items to remove

            // Now, try to find data in the tree
            BinaryTreeNode<T> current = root, parent = null;
            int result = comparer.Compare(current.Value, data);
            while (result != 0)
            {
                if (result > 0)
                {
                    // current.Value > data, if data exists it's in the left subtree
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // current.Value < data, if data exists it's in the right subtree
                    parent = current;
                    current = current.Right;
                }

                // If current == null, then we didn't find the item to remove
                if (current == null)
                    return false;
                else
                    result = comparer.Compare(current.Value, data);
            }

            // At this point, we've found the node to remove
            Count--;

            // We now need to "rethread" the tree
            // CASE 1: If current has no right child, then current's left child becomes
            //         the node pointed to by the parent
            if (current.Right == null)
            {
                if (parent == null)
                    root = current.Left;
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        // parent.Value > current.Value, so make current's left child a left child of parent
                        parent.Left = current.Left;
                    else if (result < 0)
                        // parent.Value < current.Value, so make current's left child a right child of parent
                        parent.Right = current.Left;
                }
            }
            // CASE 2: If current's right child has no left child, then current's right child
            //         replaces current in the tree
            else if (current.Right.Left == null)
            {
                if (parent == null)
                    root = current.Right;
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        // parent.Value > current.Value, so make current's right child a left child of parent
                        parent.Left = current.Right;
                    else if (result < 0)
                        // parent.Value < current.Value, so make current's right child a right child of parent
                        parent.Right = current.Right;
                }
            }
            // CASE 3: If current's right child has a left child, replace current with current's
            //          right child's left-most descendent
            else
            {
                // We first need to find the right node's left-most child
                BinaryTreeNode<T> leftmost = current.Right.Left, lmParent = current.Right;
                while (leftmost.Left != null)
                {
                    lmParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // the parent's left subtree becomes the leftmost's right subtree
                lmParent.Left = leftmost.Right;

                // assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                    root = leftmost;
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        // parent.Value > current.Value, so make leftmost a left child of parent
                        parent.Left = leftmost;
                    else if (result < 0)
                        // parent.Value < current.Value, so make leftmost a right child of parent
                        parent.Right = leftmost;
                }
            }

            return true;
        }
        #endregion

        /// <summary>
        /// clear tree
        /// </summary>
        public void Clear() => root = null;

        /// <summary>
        /// return number of element in tree
        /// </summary>
        public int Count { get; private set; }


        #region Traversal
        /// <summary>
        /// return inorder traversal
        /// </summary>
        public IEnumerable<T> InOrder
        {
            get
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> temp = root;
                while (stack.Count != 0 || temp != null)
                {
                    if (temp != null)
                    {
                        stack.Push(temp);
                        temp = temp.Left;
                    }
                    else
                    {
                        temp = stack.Pop();
                        yield return temp.Value;
                        temp = temp.Right;
                    }
                }
            }
        }

        /// <summary>
        /// return preorder traversal
        /// </summary>
        public IEnumerable<T> PreOrder
        {
            get
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                stack.Push(root);
                while (true)
                {
                    if (stack.Count == 0) break;

                    BinaryTreeNode<T> temp = stack.Pop();
                    yield return temp.Value;

                    if (temp.Right != null)
                    {
                        stack.Push(temp.Right);
                    }

                    if (temp.Left != null)
                    {
                        stack.Push(temp.Left);
                    }
                }
            }
        }

        /// <summary>
        /// return postorder traversal
        /// </summary>
        public IEnumerable<T> PostOrder => RecursionPostOrder(root);

        public bool IsReadOnly => false;

        private static IEnumerable<T> RecursionPostOrder(BinaryTreeNode<T> node)
        {
            if (node == null) yield break;

            if (node.Left != null)
            {
                foreach (var item in RecursionPostOrder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in RecursionPostOrder(node.Right))
                {
                    yield return item;
                }
            }
            yield return node.Value;
        }


        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrder.GetEnumerator();
        }

        /// <summary>
        /// copy elements of tree in inorder traversal to array
        /// </summary>
        /// <param name="array">array to which elements are copied</param>
        /// <param name="index">index from which starts copying</param>
        /// <exception cref="ArgumentNullException">throws when array is null</exception>
        /// <exception cref="ArgumentException">throws when index is invalid</exception>
        public void CopyTo(T[] array, int index)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException($"{nameof(array)} is null");
            if (index < 0) throw new ArgumentException($"{nameof(index)} is less than zero");

            int i = 0;
            foreach (var item in InOrder)
            {
                if (i >= Count) break;
                if (index + i >= array.Length) break;
                array[index + i] = item;
                i++;
            }
        }

    }
}
