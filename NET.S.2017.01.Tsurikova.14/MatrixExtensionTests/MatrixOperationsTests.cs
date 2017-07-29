using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using MatrixExtensions;
using NUnit.Framework;

namespace MatrixExtensionTests
{
    [TestFixture]
    public class MatrixOperationsTests
    {
        [Test]
        public static void Add_DiagVSDiag_Diag()
        {
            DiagonalMatrix<int> matrix1 = new DiagonalMatrix<int>(3, new[] { -1, -2, -3 });
            DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(3, new[] { 2, 4, 6 });
            DiagonalMatrix<int> matrixR = new DiagonalMatrix<int>(3, new[] { 1, 2, 3 });
            DiagonalMatrix<int> matrixE = matrix1.Add(matrix2);

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_DiagVSSym_Sym()
        {
            DiagonalMatrix<int> matrix1 = new DiagonalMatrix<int>(3, new[] { 1, 1, 1 });
            SymmetricMatrix<int> matrix2 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            SymmetricMatrix<int> matrixE = matrix1.Add(matrix2);
            SymmetricMatrix<int> matrixR = new SymmetricMatrix<int>(3, new[] { 2, 1, 1, 3, 2, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_SymVSDiag_Sym()
        {
            DiagonalMatrix<int> matrix1 = new DiagonalMatrix<int>(3, new[] { 1, 1, 1 });
            SymmetricMatrix<int> matrix2 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            SymmetricMatrix<int> matrixE = matrix2.Add(matrix1);
            SymmetricMatrix<int> matrixR = new SymmetricMatrix<int>(3, new[] { 2, 1, 1, 3, 2, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_AbsVSDiag_Sq()
        {
            DiagonalMatrix<int> matrix1 = new DiagonalMatrix<int>(3, new[] { 1, 1, 1 });
            AbstractMatrix<int> matrix2 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            SquareMatrix<int> matrixE = matrix2.Add(matrix1);
            SquareMatrix<int> matrixR = new SquareMatrix<int>(3, new[] { 2, 1, 1, 1, 3, 2, 1, 2, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_AbsVSAbs_Sq()
        {
            AbstractMatrix<int> matrix1 = new DiagonalMatrix<int>(3, new[] { 1, 1, 1 });
            AbstractMatrix<int> matrix2 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            SquareMatrix<int> matrixE = matrix2.Add(matrix1);
            SquareMatrix<int> matrixR = new SquareMatrix<int>(3, new[] { 2, 1, 1, 1, 3, 2, 1, 2, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_SqVSDiag_Sq()
        {
            DiagonalMatrix<int> matrix1 = new DiagonalMatrix<int>(3, new[] { 1, 1, 1 });
            SquareMatrix<int> matrix2 = new SquareMatrix<int>(3, new[] { 1, 1, 1, 1, 2, 2, 1, 2, 3 });
            SquareMatrix<int> matrixE = matrix2.Add(matrix1);
            SquareMatrix<int> matrixR = new SquareMatrix<int>(3, new[] { 2, 1, 1, 1, 3, 2, 1, 2, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_DiagVSSq_Sq()
        {
            DiagonalMatrix<int> matrix1 = new DiagonalMatrix<int>(3, new[] { 1, 1, 1 });
            SquareMatrix<int> matrix2 = new SquareMatrix<int>(3, new[] { 1, 1, 1, 1, 2, 2, 1, 2, 3 });
            SquareMatrix<int> matrixE = matrix1.Add(matrix2);
            SquareMatrix<int> matrixR = new SquareMatrix<int>(3, new[] { 2, 1, 1, 1, 3, 2, 1, 2, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_SymVSSym_Sym()
        {
            SymmetricMatrix<int> matrix1 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 1, 1, 1 });
            SymmetricMatrix<int> matrix2 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            SymmetricMatrix<int> matrixE = matrix2.Add(matrix1);
            SymmetricMatrix<int> matrixR = new SymmetricMatrix<int>(3, new[] { 2, 2, 2, 3, 3, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_AbsVSSym_Sq()
        {
            AbstractMatrix<int> matrix1 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 1, 1, 1 });
            SymmetricMatrix<int> matrix2 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            SquareMatrix<int> matrixE = matrix2.Add(matrix1);
            SquareMatrix<int> matrixR = new SquareMatrix<int>(3, new[] { 2, 2, 2, 2, 3, 3, 2, 3, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_SymVSAbs_Sq()
        {
            AbstractMatrix<int> matrix1 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 1, 1, 1 });
            SymmetricMatrix<int> matrix2 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            SquareMatrix<int> matrixE = matrix1.Add(matrix2);
            SquareMatrix<int> matrixR = new SquareMatrix<int>(3, new[] { 2, 2, 2, 2, 3, 3, 2, 3, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_SymVSSq_Sq()
        {
            SquareMatrix<int> matrix1 = new SquareMatrix<int>(3, new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            SymmetricMatrix<int> matrix2 = new SymmetricMatrix<int>(3, new[] { 1, 1, 1, 2, 2, 3 });
            SquareMatrix<int> matrixE = matrix1.Add(matrix2);
            SquareMatrix<int> matrixR = new SquareMatrix<int>(3, new[] { 2, 2, 2, 2, 3, 3, 2, 3, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }

        [Test]
        public static void Add_SqVSSq_Sq()
        {
            SquareMatrix<int> matrix1 = new SquareMatrix<int>(3, new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            SquareMatrix<int> matrix2 = new SquareMatrix<int>(3, new[] { 1, 1, 1, 1, 2, 2, 1, 2, 3 });
            SquareMatrix<int> matrixE = matrix1.Add(matrix2);
            SquareMatrix<int> matrixR = new SquareMatrix<int>(3, new[] { 2, 2, 2, 2, 3, 3, 2, 3, 4 });

            for (int i = 1; i <= matrixR.Size; i++)
            {
                for (int j = 1; j <= matrixR.Size; j++)
                {
                    Assert.AreEqual(matrixR[i, j], matrixE[i, j]);
                }
            }
        }
    }
}
