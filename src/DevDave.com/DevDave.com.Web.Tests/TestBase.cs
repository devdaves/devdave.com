using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDave.Com.Web.Tests
{
    /// <summary>
    /// Test Base Class
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// Gets or sets the mock context.
        /// </summary>
        /// <value>
        /// The mock context.
        /// </value>
        public MockContext MockContext { get; set; }

        /// <summary>
        /// Sets up the HTTP mock.
        /// </summary>
        internal void SetupHttpMock()
        {
            this.MockContext = new MockContext();
        }
    }
}
