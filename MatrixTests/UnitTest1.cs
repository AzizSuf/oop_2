using MatrixMultiplication;

namespace MatrixTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MatrixMultiplyTest1_DefaultTest()
        {
            int[,] matrix1 =
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9},
            };

            int[,] matrix2 =
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9},
            };

            int[,] expected =
            {
                { 30, 36, 42},
                { 66, 81, 96},
                { 102, 126, 150},
            };

            int[,] actual = MatrixOp.MatrixMultiply(matrix1, matrix2);

            CollectionAssert.AreEqual(expected, actual);  // Assert.AreEqual() Doesn't work!!
        }

        [TestMethod]
        public void MatrixMultiplyTest2_NegativeValue()
        {
            int[,] matrix1 =
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9},
            };

            int[,] matrix2 =
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, -8, 9},
            };

            Assert.ThrowsException<ArgumentException>(() => MatrixOp.MatrixMultiply(matrix1, matrix2));
        }

        [TestMethod]
        public void MatrixMultiplyTest3_IncompatibleMatricies()
        {
            int[,] matrix1 =
{
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9},
            };

            int[,] matrix2 =
            {
                { 1, 2, 3},
                { 4, 5, 6},
            };

            Assert.ThrowsException<ArgumentException>(() => MatrixOp.MatrixMultiply(matrix1, matrix2));
        }
    }
}