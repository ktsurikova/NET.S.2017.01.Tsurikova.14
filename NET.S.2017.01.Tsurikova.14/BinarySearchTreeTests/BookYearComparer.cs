﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace BinarySearchTreeTests
{
    /// <summary>
    /// class for comparing books by year of publication
    /// </summary>
    public class BookYearComparer : IComparer<Book>
    {
        /// <summary>
        /// compare 2 books by year of publication
        /// </summary>
        /// <param name="lhs">fisrt book</param>
        /// <param name="rhs">second book</param>
        /// <returns>value indicating whether first book is bigger</returns>
        /// <exception cref="ArgumentNullException">throws when lhs or rhs is null</exception>
        public int Compare(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException($"{nameof(lhs)} is null");
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException($"{nameof(rhs)} is null");
            return lhs.YearOfPublication.CompareTo(rhs.YearOfPublication);
        }
    }
}
