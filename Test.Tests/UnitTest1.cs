using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODO.Controllers;


namespace Test.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            var controller = new TasksController();
            var result = controller.Index() as ViewResult;
            var product = (Product)result.ViewData.Model;
            Assert.AreEqual("ViewAll", product.Name);
        }
    }
}
