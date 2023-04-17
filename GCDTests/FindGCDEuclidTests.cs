using Ex1_GCD;

namespace GCDTests
{
    [TestClass]
    public class FindGCDEuclidTests
    {
        [TestMethod]
        public void FindGCDEuclid_With2Parameters_25_125_Test()
        {
            int result = GCDAlgorithms.FindGCDEuclid(25, 125);
            int expected = 25;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindGCDEuclid_With2Parameters_27_255_Test()
        {
            int result = GCDAlgorithms.FindGCDEuclid(27, 255);
            int expected = 3;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindGCDEuclid_With3Parameters_25_125_625_Test()
        {
            int result = GCDAlgorithms.FindGCDEuclid(25, 125, 625);
            int expected = 25;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindGCDEuclid_With3Parameters_325_150_120_Test()
        {
            int result = GCDAlgorithms.FindGCDEuclid(325, 150, 120);
            int expected = 5;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindGCDEuclid_With4Parameters_45_12_78_45_Test()
        {
            int result = GCDAlgorithms.FindGCDEuclid(45, 12, 78, 45);
            int expected = 3;
            Assert.AreEqual(expected, result);
        }
    }
}