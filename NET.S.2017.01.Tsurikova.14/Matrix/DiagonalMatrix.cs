using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// class for working with diagonal matrices
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        private T[] elements;

        /// <summary>
        /// initializes a new instance of matrix with the specified dimension
        /// </summary>
        /// <param name="dimension">dimension of matrix</param>
        public DiagonalMatrix(int dimension)
        {
            Dimension = dimension;
            elements = new T[dimension];
        }

        /// <summary>
        /// initializes a new instance of matrix with the specified dimension and elements
        /// </summary>
        /// <param name="dimension">dimension of matrix</param>
        /// <param name="elements">elements of matrix</param>
        public DiagonalMatrix(int dimension, T[] elements) : this(dimension)
        {
            for (int i = 0; i < this.elements.Length && i < elements.Length; i++)
            {
                this.elements[i] = elements[i];
            }
        }

        protected override T GetElement(int i, int j)
        {
            BasicCheckPosition(i, j);
            return i == j ? elements[i - 1] : default(T);
        }

        protected override void SetElement(int i, int j, T value)
        {
            BasicCheckPosition(i, j);
            if (i != j) throw new ArgumentException
                      ("other than the default values can be only the elements on the main diagonal");
            elements[i - 1] = value;
        }
    }
}
