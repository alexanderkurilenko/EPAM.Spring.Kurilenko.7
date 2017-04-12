using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Logic;

namespace Task1Tests
{
    [TestClass]
    public class CustomerUnitTests
    {
        [TestMethod]
        public void StandartOutPutTestWithStandartCtor()
        {
            Customer cst = new Customer();
            string result = "Customer record: Alex, +000000000, 0";
            Assert.AreEqual(result, cst.ToString(null));
        }

        [TestMethod]
        public void StandartOutPutTest()
        {
            Customer cst = new Customer("Alex","+375336104533",500);
            string result = "Customer record: Alex, +375336104533, 500";
            Assert.AreEqual(result, cst.ToString(null));
        }

        [TestMethod]
        public void NOutPutTest()
        {
            Customer cst = new Customer("Alex", "+375336104533", 500);
            string result = "Customer record: Alex";
            Assert.AreEqual(result, cst.ToString("N"));
        }

        [TestMethod]
        public void NPOutPutTest()
        {
            Customer cst = new Customer("Alex", "+375336104533", 500);
            string result = "Customer record: Alex, +375336104533";
            Assert.AreEqual(result, cst.ToString("NP"));
        }

        [TestMethod]
        public void POutPutTest()
        {
            Customer cst = new Customer("Alex", "+375336104533", 500);
            string result = "Customer record: +375336104533";
            Assert.AreEqual(result, cst.ToString("P"));
        }


        [TestMethod]
        public void ROutPutTest()
        {
            Customer cst = new Customer("Alex", "+375336104533", 500);
            string result = "Customer record: 500";
            Assert.AreEqual(result, cst.ToString("R"));
        }
    }
}
