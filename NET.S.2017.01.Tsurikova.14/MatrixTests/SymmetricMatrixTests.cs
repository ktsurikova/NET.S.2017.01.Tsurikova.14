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
    public class SymmetricMatrixTests
    {
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(3, 1, ExpectedResult = 1)]
        [TestCase(1, 3, ExpectedResult = 1)]
        public static int Indexer_Position_Value(int i, int j)
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            int k = Math.Max(i - 1, j - 1) * (Math.Max(i - 1, j - 1) + 1) / 2 + Math.Min(i - 1, j - 1);
            return matrix[i, j];
        }

        [TestCase(0, 0)]
        [TestCase(-10, -1)]
        public static void Indexer_WrongPosition_ArgumentException(int i, int j)
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            Assert.Throws<ArgumentException>(() =>
            {
                matrix[i, j] = 1;
            });
        }
    }
}
