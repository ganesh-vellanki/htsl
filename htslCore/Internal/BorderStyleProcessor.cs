using DocumentFormat.OpenXml.Spreadsheet;
using htslCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslCore.Internal
{
    /// <summary>
    /// Border Style Processor
    /// </summary>
    /// <seealso cref="htslCore.Internal.IStyleProcessor{htslCore.Model.HtslCellStyle}" />
    internal class BorderStyleProcessor : IStyleProcessor<HtslCellStyle>
    {

        /// <summary>
        /// Gets the style.
        /// </summary>
        /// <param name="styleAttr">The style attribute string</param>
        /// <returns>
        /// a processed style
        /// </returns>
        public HtslCellStyle GetStyle(string styleAttr)
        {
            HtslCellStyle style = new HtslCellStyle();

            var attrValues = styleAttr.Split(' ');

            if(attrValues.Length == 3)
            {
                style.Border.SetHorizontalBorder(BorderStyleValues.Thin, (System.Drawing.Color)System.Drawing.ColorTranslator.FromHtml(attrValues[2]));
                style.Border.SetVerticalBorder(BorderStyleValues.Thin, (System.Drawing.Color)System.Drawing.ColorTranslator.FromHtml(attrValues[2]));
            }

            return style;
        }
    }
}
