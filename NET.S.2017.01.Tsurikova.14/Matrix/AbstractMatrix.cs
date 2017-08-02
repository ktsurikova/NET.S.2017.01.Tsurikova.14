using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// class providing data for change element event
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public class ChangeElementEventArgs<T> : EventArgs
    {
        public int Row { get; }
        public int Column { get; }

        /// <summary>
        /// old value
        /// </summary>
        public T Old { get; }

        /// <summary>
        /// new value
        /// </summary>
        public T New { get; }

        public ChangeElementEventArgs(int row, int column, T oldElement, T newElement)
        {
            Row = row;
            Column = column;
            Old = oldElement;
            New = newElement;
        }
    }

    /// <summary>
    /// abstaract class for matrices
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public abstract class AbstractMatrix<T>
    {
        private int size;

        /// <summary>
        /// size of matrix
        /// </summary>
        public int Size
        {
            get { return size; }
            protected set
            {
                if (value < 0) throw new ArgumentException($"{nameof(Size)} can't be negative");
                size = value;
            }
        }

        /// <summary>
        /// event when element changes
        /// </summary>
        public event EventHandler<ChangeElementEventArgs<T>> ChangeElement = delegate { };

        /// <summary>
        /// Provides access to items by indexes
        /// INDEXING FROM 1!
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>element</returns>
        /// <exception cref="ArgumentException">throws when indexes are wrong</exception>
        public T this[int i, int j]
        {
            get
            {
                BasicCheckPosition(i, j);
                return GetElement(i, j);
            }
            set
            {
                BasicCheckPosition(i, j);
                T old = GetElement(i, j);
                SetElement(i, j, value);
                OnChangeElement(new ChangeElementEventArgs<T>(i, j, old, value));
            }
        }

        protected void BasicCheckPosition(int i, int j)
        {
            if ((i <= 0) || (i > Size) || (j <= 0) || (j > Size))
                throw new ArgumentException($"invalid ({i}, {j}) indexes of position");
        }

        protected abstract T GetElement(int i, int j);
        protected abstract void SetElement(int i, int j, T value);

        private void OnChangeElement(ChangeElementEventArgs<T> args)
        {
            EventHandler<ChangeElementEventArgs<T>> temp = ChangeElement;
            temp?.Invoke(this, args);
        }
    }
}
