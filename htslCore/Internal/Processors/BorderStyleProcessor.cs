using DocumentFormat.OpenXml.Spreadsheet;
using htslCore.Internal.Processors;
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
    internal class BorderStyleProcessor : StyleProcessor, IStyleProcessor<HtslCellStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorderStyleProcessor"/> class.
        /// </summary>
        /// <param name="cellStyle"></param>
        public BorderStyleProcessor(HtslCellStyle cellStyle) 
            : base(cellStyle)
        {
        }

        /// <summary>
        /// Gets the style.
        /// </summary>
        /// <param name="styleAttr">The style attribute string</param>
        /// <returns>
        /// a processed style
        /// </returns>
        public HtslCellStyle GetStyle(string styleAttr)
        {
            var attrValues = styleAttr.Split(' ');

            if(attrValues.Length == 3)
            {
                base.CellStyle.Border.SetHorizontalBorder(BorderStyleValues.Thin, (System.Drawing.Color)System.Drawing.ColorTranslator.FromHtml(attrValues[2]));
                base.CellStyle.Border.SetVerticalBorder(BorderStyleValues.Thin, (System.Drawing.Color)System.Drawing.ColorTranslator.FromHtml(attrValues[2]));
            }

            return base.CellStyle;
        }
    }
}
