using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// class for working with symmetric matrices
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public class SymmetricMatrix<T> : AbstractMatrix<T>
    {
        private T[] elements;

        /// <summary>
        /// initializes a new instance of matrix with the specified size
        /// </summary>
        /// <param name="size">size of matrix</param>
        public SymmetricMatrix(int size)
        {
            Size = size;
            elements = new T[Size * (Size + 1) / 2];
        }

        /// <summary>
        /// initializes a new instance of matrix with the specified size and elements
        /// </summary>
        /// <param name="size">size of matrix</param>
        /// <param name="elements">elements of matrix</param>
        public SymmetricMatrix(int size, T[] elements) : this(size)
        {
            for (int i = 0; i < this.elements.Length && i < elements.Length; i++)
            {
                this.elements[i] = elements[i];
            }
        }

        protected override T GetElement(int i, int j)
        {
            BasicCheckPosition(i, j);
            return elements[GetIndex(i, j)];
        }

        protected override void SetElement(int i, int j, T value)
        {
            BasicCheckPosition(i, j);
            elements[GetIndex(i, j)] = value;
        }

        private int GetIndex(int i, int j)
        {
            if (i < j)
                return (i - 1) * Size - (i - 1) * i / 2 + j - 1;
            return (j - 1) * Size - (j - 1) * j / 2 + i - 1;
        }
    }
}
