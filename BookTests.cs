using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class BookTests
    {


        [TestMethod()]

        public void ToStringTest()
        {

            var book = new Book(124, 393, "noget");


            string result = book.ToString();

            Assert.AreEqual("ID124 Titlenoget Price393", result);
        }

        [TestMethod()]
        public void ValidateTitleTest()
        {

            var book = new Book(124, 393, "noget");

            try
            {
                book.ValidateTitle(book.Title);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod()]
        public void INValidateTitleTest()
        {

            var book = new Book(124, 393, "no");

            try
            {
                book.ValidateTitle(book.Title);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Title skal vøre mindst 3", ex.Message);
            }
        }

        [TestMethod()]
        public void ValdiDatePriceTest()
        {

            var book = new Book(124, 393, "noget");

            try
            {
                book.ValdiDatePrice(book.Price);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod()]
        public void INValdiDatePriceTest()
        {

            var book = new Book(124, 39323, "noget");

            try
            {
                book.ValdiDatePrice(book.Price);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("pris skal være mellem 0 og 1200", ex.Message);
            }
        }
    }
}