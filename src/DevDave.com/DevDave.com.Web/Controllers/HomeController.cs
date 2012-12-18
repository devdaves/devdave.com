using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevDave.Com.Web.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index action, default
        /// </summary>
        /// <returns>returns the index page</returns>
        public ActionResult Index()
        {
            return this.View("Index");
        }

        /// <summary>
        /// About action
        /// </summary>
        /// <returns>returns the about page</returns>
        public ActionResult About()
        {
            return this.View("About");
        }

        /// <summary>
        /// Resume action
        /// </summary>
        /// <returns>returns the resume page</returns>
        public ActionResult Resume()
        {
            return this.RedirectPermanent("http://careers.stackoverflow.com/devdaves");
        }
    }
}
