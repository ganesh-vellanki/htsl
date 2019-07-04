using htslCore.Internal;
using htslCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslCore.Main
{
    /// <summary>
    /// Style Affixer
    /// </summary>
    internal class StyleAffixer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StyleAffixer"/> class.
        /// </summary>
        public StyleAffixer()
        {
        }

        /// <summary>
        /// Binds the style.
        /// </summary>
        /// <param name="styleProcessor">The style processor.</param>
        /// <param name="styleAttr">The style attribute.</param>
        /// <returns></returns>
        public StyleAffixer BindStyle(IStyleProcessor<HtslCellStyle> styleProcessor, string styleAttr)
        {
            styleProcessor.GetStyle(styleAttr);
            return this;
        }
    }
}
