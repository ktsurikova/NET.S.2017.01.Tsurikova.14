using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// class for working with square matrices
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T> : AbstractMatrix<T>
    {
        private T[] elements;

        /// <summary>
        /// initializes a new instance of matrix with the specified size
        /// </summary>
        /// <param name="size">size of matrix</param>
        public SquareMatrix(int size)
        {
            Size = size;
            elements = new T[size * size];
        }

        /// <summary>
        /// initializes a new instance of matrix with the specified size and elements
        /// </summary>
        /// <param name="size">size of matrix</param>
        /// <param name="elements">elements of matrix</param>
        public SquareMatrix(int size, T[] elements) : this(size)
        {
            for (int i = 0; i < this.elements.Length && i < elements.Length; i++)
            {
                this.elements[i] = elements[i];
            }
        }

        protected override T GetElement(int i, int j)
        {
            BasicCheckPosition(i, j);
            return elements[Size * (i - 1) + j - 1];
        }

        protected override void SetElement(int i, int j, T value)
        {
            BasicCheckPosition(i, j);
            elements[Size * (i - 1) + j - 1] = value;
        }

    }
}
