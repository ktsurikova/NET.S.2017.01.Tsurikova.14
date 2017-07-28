using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : AbstractMatrix<T>
    {
        private T[] elements;

        public SquareMatrix(int dimension)
        {
            Dimension = dimension;
            elements = new T[dimension * dimension];
        }

        public SquareMatrix(int dimension, T[] elements) : this(dimension)
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                this.elements[i] = elements[i];
            }
        }

        protected override T GetElement(int i, int j)
        {
            BasicCheckPosition(i, j);
            return elements[Dimension * (i - 1) + j - 1];
        }

        protected override void SetElement(int i, int j, T value)
        {
            BasicCheckPosition(i, j);
            elements[Dimension * (i - 1) + j - 1] = value;
        }

    }
}
