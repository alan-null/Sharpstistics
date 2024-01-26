using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sharpstistics.Test
{
    [TestClass]
    public class SharpstisticsTests
    {
        readonly double[] _x = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        readonly double[] _y = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 12 };
        private const double Delta = 0.00001;

        [TestMethod]
        public void Average_for_x()
        {
            double average = Math.Average(_x);
            Assert.AreEqual(10, average);
        }

        [TestMethod]
        public void Average_for_y()
        {
            double average = Math.Average(_y);
            Assert.AreEqual(10.2, average);
        }

        [TestMethod]
        public void Standard_deviation_for_x()
        {
            double standardDeviation = Math.StandardDeviation(_x);
            Assert.AreEqual(0.0, standardDeviation);
        }

        [TestMethod]
        public void Standard_deviation_for_y()
        {
            double standardDeviation = Math.StandardDeviation(_y);
            Assert.AreEqual(0.6, standardDeviation);
        }

        [TestMethod]
        public void Student_table_test()
        {
            Assert.AreEqual(1.8856, StudentTable.GetStudentValue(2, 0.2));
            Assert.AreEqual(0.6901, StudentTable.GetStudentValue(16, 0.5));

            Assert.AreEqual(3.2614, StudentTable.GetStudentValue(50, 0.002));
            Assert.AreEqual(1.2816, StudentTable.GetStudentValue(502, 0.2));

            Assert.AreEqual(3.3101, StudentTable.GetStudentValue(500, 0.001));
            Assert.AreEqual(2.7638, StudentTable.GetStudentValue(10, 0.02));
        }

        [TestMethod]
        public void Confidence_interval_for_x()
        {
            double confidenceInterval = Math.ConfidenceInterval(_x, 1.96);
            Assert.AreEqual(0, confidenceInterval, Delta);
        }

        [TestMethod]
        public void Confidence_interval_for_y()
        {
            double confidenceInterval = Math.ConfidenceInterval(_y, 1.96);
            Assert.AreEqual(7.291840252, confidenceInterval, Delta);
        }

        [TestMethod]
        public void Confidence_interval_endpoints_for_x()
        {
            Endpoints endpoints = Math.ConfidenceIntervalEndpoints(_x, 1.96);
            Assert.AreEqual(10.0, endpoints.Left, Delta);
            Assert.AreEqual(10.0, endpoints.Right, Delta);
        }

        [TestMethod]
        public void Confidence_interval_endpoints_for_y()
        {
            Endpoints endpoints = Math.ConfidenceIntervalEndpoints(_y, 1.96);
            Assert.AreEqual(9.8281161471641987, endpoints.Left, Delta);
            Assert.AreEqual(10.5718838528358, endpoints.Right, Delta);
        }
    }
}
