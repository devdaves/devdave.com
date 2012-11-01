using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace DevDave.Com.Web.Tests
{
    /// <summary>
    /// Routing Tests
    /// </summary>
    [TestClass]
    public class RoutingTests : TestBase
    {
        /// <summary>
        /// route collection field
        /// </summary>
        private RouteCollection routeCollection;

        /// <summary>
        /// Run before every test
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.routeCollection = RouteTable.Routes;
            this.routeCollection.Clear();
            DevDave.Com.Web.RouteConfig.RegisterRoutes(this.routeCollection);

            this.SetupHttpMock();
        }

        /// <summary>
        /// / URL should go to Home controller and Index action
        /// </summary>
        [TestMethod]
        public void Empty_URL_Should_Go_To_HomeController_IndexAction()
        {
            this.TestRoute("~/", "Home", "Index");
        }

        /// <summary>
        /// /Home URL should go to Home controller and Index action
        /// </summary>
        [TestMethod]
        public void Home_URL_Should_Go_To_HomeController_IndexAction()
        {
            this.TestRoute("~/Home", "Home", "Index");
        }

        /// <summary>
        /// Old /AboutMe URL should go to the Home controller and About action
        /// </summary>
        [TestMethod]
        public void AboutMe_Url_Should_Go_To_HomeContrller_AboutAction()
        {
            this.TestRoute("~/AboutMe", "Home", "About");
        }

        /// <summary>
        /// Old /AboutSite URL should go to the Home controller and About action
        /// </summary>
        [TestMethod]
        public void AboutSite_URL_Should_Go_To_HomeController_AboutAction()
        {
            this.TestRoute("~/AboutSite", "Home", "About");
        }

        /// <summary>
        /// /Resume URL should go to the Home Controller and Resume action
        /// </summary>
        [TestMethod]
        public void Resume_URL_Should_Go_To_HomeController_ResumeAction()
        {
            this.TestRoute("~/Resume", "Home", "Resume");
        }

        /// <summary>
        /// Old /Projects URL is not supported and should go back to the Home controller and Index action
        /// </summary>
        [TestMethod]
        public void Projects_URL_Should_Go_To_HomeController_IndexAction()
        {
            this.TestRoute("~/Projects", "Home", "Index");
        }

        /// <summary>
        /// /Home/Index URL should go to Home controller and Index action
        /// </summary>
        [TestMethod]
        public void Home_Index_URL_Should_Go_To_HomeController_IndexAction()
        {
            this.TestRoute("~/Home/Index", "Home", "Index");
        }

        /// <summary>
        /// /Home/About URL should go to Home controller and About action
        /// </summary>
        [TestMethod]
        public void Home_About_URL_Should_Go_To_HomeController_AboutAction()
        {
            this.TestRoute("~/Home/About", "Home", "About");
        }

        /// <summary>
        /// /Home/Resume URL should go to Home controller and Resume action
        /// </summary>
        [TestMethod]
        public void Home_Resume_URL_Should_Go_To_HomeController_ResumeAction()
        {
            this.TestRoute("~/Home/Resume", "Home", "Resume");
        }

        /// <summary>
        /// Tests the route.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="expectedController">The expected controller.</param>
        /// <param name="expectedAction">The expected action.</param>
        private void TestRoute(string url, string expectedController, string expectedAction)
        {
            var r = this.GetRoute(url);
            Assert.IsNotNull(r, "Did not find the route");
            Assert.AreEqual(expectedController, r.Values["Controller"]);
            Assert.AreEqual(expectedAction, r.Values["Action"]);        
        }

        /// <summary>
        /// Gets the route.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>returns the route</returns>
        private RouteData GetRoute(string url)
        {
            MockContext.Http.Setup(x => x.Request.Path).Returns(url);
            MockContext.Http.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            var r = this.routeCollection.GetRouteData(MockContext.Http.Object);
            if (r.RouteHandler is RouteMagic.Internals.RedirectRoute)
            {
                var redirectUrl = string.Format("~/{0}", ((r.RouteHandler as RouteMagic.Internals.RedirectRoute).TargetRoute as Route).Url);
                return this.GetRoute(redirectUrl);
            }
            return r;
        }
    }
}
