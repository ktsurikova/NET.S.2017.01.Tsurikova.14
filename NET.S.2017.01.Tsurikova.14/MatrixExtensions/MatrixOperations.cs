﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using Microsoft.CSharp.RuntimeBinder;

namespace MatrixExtensions
{
    public static class MatrixOperations
    {
        public static SquareMatrix<T> Add<T>(this AbstractMatrix<T> lhs, AbstractMatrix<T> rhs)
        {
            if (lhs.Dimension != rhs.Dimension)
                throw new InvalidOperationException("only matrices with the same size can be added");

            SquareMatrix<T> result = new SquareMatrix<T>(lhs.Dimension);

            try
            {
                for (int i = 1; i <= result.Dimension; i++)
                {
                    for (int j = 1; j <= result.Dimension; j++)
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

        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            if (lhs.Dimension != rhs.Dimension)
                throw new InvalidOperationException("only matrices with the same size can be added");

            DiagonalMatrix<T> result = new DiagonalMatrix<T>(lhs.Dimension);

            try
            {
                for (int i = 1; i <= result.Dimension; i++)
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

        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            if (lhs.Dimension != rhs.Dimension)
                throw new InvalidOperationException("only matrices with the same size can be added");

            SymmetricMatrix<T> result = new SymmetricMatrix<T>(lhs.Dimension);

            try
            {
                for (int i = 1; i <= result.Dimension; i++)
                {
                    for (int j = 1; j <= result.Dimension; j++)
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

        public static SymmetricMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            if (lhs.Dimension != rhs.Dimension)
                throw new InvalidOperationException("only matrices with the same size can be added");

            SymmetricMatrix<T> result = new SymmetricMatrix<T>(lhs.Dimension);

            try
            {
                for (int i = 1; i <= result.Dimension; i++)
                {
                    for (int j = 1; j <= result.Dimension; j++)
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

        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs) => Add(rhs, lhs);


    }
}