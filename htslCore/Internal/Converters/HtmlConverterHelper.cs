using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslCore.Internal.Converters
{
    /// <summary>
    /// Html converter helper
    /// </summary>
    internal class HtmlConverterHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlConverterHelper"/> class.
        /// </summary>
        public HtmlConverterHelper()
        {
        }

        /// <summary>
        /// Gets the new HTML document.
        /// </summary>
        /// <returns>Html Document</returns>
        public HtmlDocument GetNewHtmlDocument(string htmlString)
        {
            var htmlDoc = new HtmlDocument { OptionUseIdAttribute = true };
            htmlDoc.LoadHtml(htmlString);
            return htmlDoc;
        }
    }
}
