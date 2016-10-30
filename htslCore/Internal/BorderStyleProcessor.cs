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
    /// <seealso cref="htslCore.Internal.IStyleProcessor{htslCore.Model.htslCellStyle}" />
    class BorderStyleProcessor : IStyleProcessor<htslCellStyle>
    {

        /// <summary>
        /// Gets the style.
        /// </summary>
        /// <param name="styleAttr">The style attribute string</param>
        /// <returns>
        /// a processed style
        /// </returns>
        public htslCellStyle GetStyle(string styleAttr)
        {
            htslCellStyle style = new htslCellStyle();

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
