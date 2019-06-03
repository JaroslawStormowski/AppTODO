using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODO.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TODO.Controllers.Tests
{
    [TestClass()]
    public class TasksControllerTests
    {


        [TestMethod()]
        public void ViewAllTest()
        {

            var controller = new TasksController();
            var create_task = new TODO.Models.Task
            { Id = 0, Name = "Some task", Text = "Line of text\nAnother line of text" };
            var result = controller.ViewAll() as ViewResult;

            Assert.AreEqual("Some task", create_task.Name);

            Assert.AreEqual("ViewAll", result.ViewName);
        }

    }
}