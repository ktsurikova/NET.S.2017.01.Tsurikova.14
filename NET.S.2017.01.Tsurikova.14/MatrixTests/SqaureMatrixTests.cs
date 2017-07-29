using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using NUnit.Framework;

namespace MatrixTests
{
    [TestFixture]
    public class SqaureMatrixTests
    {
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(3, 3, ExpectedResult = 9)]
        [TestCase(1, 3, ExpectedResult = 3)]
        public static int Indexer_Position_Value(int i, int j)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            return matrix[i, j];
        }

        [TestCase(0, 0)]
        [TestCase(-10, -1)]
        public static void Indexer_WrongPosition_ArgumentException(int i, int j)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Assert.Throws<ArgumentException>(() =>
            {
                var k = matrix[i, j];
            });
        }
    }
}
