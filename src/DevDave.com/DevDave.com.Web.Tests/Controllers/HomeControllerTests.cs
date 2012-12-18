using DevDave.Com.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevDave.Com.Web.Tests.Controllers
{
    /// <summary>
    /// Home Controller tests
    /// </summary>
    [TestClass]
    public class HomeControllerTests : TestBase
    {
        /// <summary>
        /// controller field
        /// </summary>
        private HomeController controller;

        /// <summary>
        /// Before every test
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.SetupHttpMock();
            this.controller = new HomeController();
            this.controller.ControllerContext = new ControllerContext(this.MockContext.Http.Object, new RouteData(), this.controller);
        }

        /// <summary>
        /// When the index acton is called it should return the index view
        /// </summary>
        [TestMethod]
        public void IndexAction_Returns_IndexView()
        {
            this.TestViewName("Index", () => { return this.controller.Index(); });
        }

        /// <summary>
        /// When the about action is called it should return the about view
        /// </summary>
        [TestMethod]
        public void AboutAction_Returns_AboutView()
        {
            this.TestViewName("About", () => { return this.controller.About(); });
        }

        /// <summary>
        /// Tests the name of the view.
        /// </summary>
        /// <param name="expectedView">The expected view.</param>
        /// <param name="action">The action.</param>
        private void TestViewName(string expectedView, Func<ActionResult> action)
        {
            var result = action.Invoke() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedView, result.ViewName);            
        }
    }
}
