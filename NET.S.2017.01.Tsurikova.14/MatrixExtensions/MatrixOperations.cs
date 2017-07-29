using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using Microsoft.CSharp.RuntimeBinder;

namespace MatrixExtensions
{
    /// <summary>
    /// class provding operations with matrices
    /// </summary>
    public static class MatrixOperations
    {
        /// <summary>
        /// add two any type of matrices
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="lhs">first matrix</param>
        /// <param name="rhs">second matrix</param>
        /// <returns>new square matrix</returns>
        /// <exception cref="InvalidOperationException">throws when matrices can't be added</exception>
        /// <exception cref="ArgumentNullException">throws when rhs is null</exception>
        public static SquareMatrix<T> Add<T>(this AbstractMatrix<T> lhs, AbstractMatrix<T> rhs)
        {
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException($"{nameof(rhs)} is null");
            if (lhs.Size != rhs.Size)
                throw new InvalidOperationException("only matrices with the same size can be added");

            SquareMatrix<T> result = new SquareMatrix<T>(lhs.Size);

            try
            {
                for (int i = 1; i <= result.Size; i++)
                {
                    for (int j = 1; j <= result.Size; j++)
                    {
                        result[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
                    }
                }
            }
            catch (RuntimeBinderException e)
            {
                throw new InvalidOperationException("elements of matrix can't be added", e);
            }

            return result;
        }

        /// <summary>
        /// add two diagonal matrices
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="lhs">first matrix</param>
        /// <param name="rhs">second matrix</param>
        /// <returns>new diagonal matrix</returns>
        /// <exception cref="InvalidOperationException">throws when matrices can't be added</exception>
        /// <exception cref="ArgumentNullException">throws when rhs is null</exception>
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException($"{nameof(rhs)} is null");
            if (lhs.Size != rhs.Size)
                throw new InvalidOperationException("only matrices with the same size can be added");

            DiagonalMatrix<T> result = new DiagonalMatrix<T>(lhs.Size);

            try
            {
                for (int i = 1; i <= result.Size; i++)
                {
                    result[i, i] = (dynamic)lhs[i, i] + rhs[i, i];
                }
            }
            catch (RuntimeBinderException e)
            {
                throw new InvalidOperationException("elements of matrix can't be added", e);
            }

            return result;
        }

        /// <summary>
        /// add two symmetric matrices
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="lhs">first matrix</param>
        /// <param name="rhs">second matrix</param>
        /// <returns>new symmetric matrix</returns>
        /// <exception cref="InvalidOperationException">throws when matrices can't be added</exception>
        /// <exception cref="ArgumentNullException">throws when rhs is null</exception>
        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException($"{nameof(rhs)} is null");
            if (lhs.Size != rhs.Size)
                throw new InvalidOperationException("only matrices with the same size can be added");

            SymmetricMatrix<T> result = new SymmetricMatrix<T>(lhs.Size);

            try
            {
                for (int i = 1; i <= result.Size; i++)
                {
                    for (int j = 1; j <= result.Size; j++)
                    {
                        result[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
                    }
                }
            }
            catch (RuntimeBinderException e)
            {
                throw new InvalidOperationException("elements of matrix can't be added", e);
            }

            return result;
        }

        /// <summary>
        /// add diagonal and symmetric matrices
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="lhs">first matrix</param>
        /// <param name="rhs">second matrix</param>
        /// <returns>new symmetric matrix</returns>
        /// <exception cref="InvalidOperationException">throws when matrices can't be added</exception>
        /// <exception cref="ArgumentNullException">throws when rhs is null</exception>
        public static SymmetricMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException($"{nameof(rhs)} is null");
            if (lhs.Size != rhs.Size)
                throw new InvalidOperationException("only matrices with the same size can be added");

            SymmetricMatrix<T> result = new SymmetricMatrix<T>(lhs.Size);

            try
            {
                for (int i = 1; i <= result.Size; i++)
                {
                    for (int j = 1; j <= result.Size; j++)
                    {
                        result[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
                    }
                }
            }
            catch (RuntimeBinderException e)
            {
                throw new InvalidOperationException("elements of matrix can't be added", e);
            }

            return result;
        }

        /// <summary>
        /// add symmetric and diagonal matrices
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="lhs">first matrix</param>
        /// <param name="rhs">second matrix</param>
        /// <returns>new symmetric matrix</returns>
        /// <exception cref="InvalidOperationException">throws when matrices can't be added</exception>
        /// <exception cref="ArgumentNullException">throws when rhs is null</exception>
        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException($"{nameof(rhs)} is null");
            return Add(rhs, lhs);
        }

    }
}
