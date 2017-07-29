using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class ChangeElementEventArgs<T> : EventArgs
    {
        public int Row { get; }
        public int Column { get; }
        public T Old { get; }
        public T New { get; }

        public ChangeElementEventArgs(int row, int column, T oldElement, T newElement)
        {
            Row = row;
            Column = column;
            Old = oldElement;
            New = newElement;
        }
    }

    public abstract class AbstractMatrix<T>
    {
        private int dimension;
        public int Dimension
        {
            get { return dimension; }
            protected set
            {
                if (value < 0) throw new ArgumentException($"{nameof(Dimension)} can't be negative");
                dimension = value;
            }

        }

        protected void BasicCheckPosition(int i, int j)
        {
            if ((i <= 0) || (i > Dimension) || (j <= 0) || (j > Dimension))
                throw new ArgumentException($"invalid indexs of position");
        }

        public T this[int i, int j]
        {
            get
            {
                return GetElement(i, j);
            }
            set
            {
                T old = GetElement(i, j);
                SetElement(i, j, value);
                OnChangeElement(new ChangeElementEventArgs<T>(i, j, old, value));
            }
        }

        protected abstract T GetElement(int i, int j);
        protected abstract void SetElement(int i, int j, T value);

        private void OnChangeElement(ChangeElementEventArgs<T> args)
        {
            EventHandler<ChangeElementEventArgs<T>> temp = ChangeElement;
            temp?.Invoke(this, args);
        }

        public event EventHandler<ChangeElementEventArgs<T>> ChangeElement = delegate { };

    }
}
