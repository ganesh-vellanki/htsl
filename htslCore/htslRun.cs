using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using htslCore.Worker;

namespace htslCore.Run
{
    /// <summary>
    /// Core HTML to EXCEL Conversion API
    /// </summary>
    public class htslRun
    {
        /// <summary>
        /// Gets the worker.
        /// </summary>
        /// <value>
        /// The worker.
        /// </value>
        private htslWorker _worker { get { return new htslWorker(); } }

        /// <summary>
        /// Converts the HTML to xl.
        /// </summary>
        /// <remarks>A entry point to leverage conversion</remarks>
        /// <returns>A Memory Stream</returns>
        public byte[] ConvertHtmlToXL(string htmlStr)
        {
            return this._worker.ConvertHTMLToXL(htmlStr);
        }

        /// <summary>
        /// Asserts the HTML source.
        /// </summary>
        /// <param name="htmlStr">The HTML string.</param>
        /// <returns>true if html string is valid</returns>
        public bool AssertHTMLSource(string htmlStr)
        {
            return false;
        }
    }
}
