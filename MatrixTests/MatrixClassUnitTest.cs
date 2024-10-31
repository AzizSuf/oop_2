using MatrixMultiplication;

namespace MatrixTests
{
    [TestClass]
    public class MatrixClassUnitTest
    {
        [TestMethod]
        public void MatrixClass()
        {
            Matrix m1 = new Matrix(3, 3)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,
                [1, 0] = 4,
                [1, 1] = 5,
                [1, 2] = 6,
                [2, 0] = 7,
                [2, 1] = 8,
                [2, 2] = 9,
            };

            Matrix m2 = new Matrix(3, 3)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,
                [1, 0] = 4,
                [1, 1] = 5,
                [1, 2] = 6,
                [2, 0] = 7,
                [2, 1] = 8,
                [2, 2] = 9,
            };

            Matrix expected = new Matrix(3, 3)
            {
                [0, 0] = 30,
                [0, 1] = 36,
                [0, 2] = 42,
                [1, 0] = 66,
                [1, 1] = 81,
                [1, 2] = 96,
                [2, 0] = 102,
                [2, 1] = 126,
                [2, 2] = 150,
            };

            Matrix actual = m1 * m2;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void MatrixClass_Test2()
        {
            Matrix m1 = new Matrix(3, 3, new int[,]{{ 1, 2, 3},
                                                    { 4, 5, 6},
                                                    { 7, 8, 9}});

            Matrix m2 = new Matrix(3, 3, new int[,]{{ 1, 2, 3},
                                                    { 4, 5, 6},
                                                    { 7, 8, 9}});

            Matrix expected = new Matrix(3, 3, new int[,]  {
                { 30, 36, 42},
                { 66, 81, 96},
                { 102, 126, 150},
            });

            Matrix result = m1 * m2;

            Assert.AreEqual(expected, result);
        }
    }
}
