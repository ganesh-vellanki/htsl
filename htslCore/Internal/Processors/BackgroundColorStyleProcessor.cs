using htslCore.Internal.Processors;
using htslCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace htslCore.Internal
{
    /// <summary>
    /// Background color style processor
    /// </summary>
    /// <seealso cref="htslCore.Internal.IStyleProcessor{htslCore.Model.HtslCellStyle}" />
    internal class BackgroundColorStyleProcessor : StyleProcessor, IStyleProcessor<HtslCellStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundColorStyleProcessor"/> class.
        /// </summary>
        /// <param name="cellStyle"></param>
        public BackgroundColorStyleProcessor(HtslCellStyle cellStyle)
            : base(cellStyle)
        {
        }

        /// <summary>
        /// Gets the style.
        /// </summary>
        /// <param name="backgroundColor">The style attribute.</param>
        /// <returns>
        /// a processed style
        /// </returns>
        public HtslCellStyle GetStyle(string backgroundColor)
        {
            if(Regex.Match(backgroundColor, @"^#(?:[0-9a-fA-F]{3}){1,2}$").Success)
            {
                base.CellStyle.Fill.SetPatternBackgroundColor((System.Drawing.Color)System.Drawing.ColorTranslator.FromHtml(backgroundColor));
            }
            else if(Regex.Match(backgroundColor, @"/[Rr][Gg][Bb][Aa][\(](((([\d]{1,3}|[\d\.]{1,3})[\,]{0,1})[\s]*){4})[\)]/gm").Success)
            {
                backgroundColor.Remove(0, 4);
                backgroundColor.Replace("(", string.Empty);
                backgroundColor.Replace(")", string.Empty);
                base.CellStyle.Fill.SetPatternBackgroundColor(System.Drawing.Color.FromArgb(backgroundColor[3], backgroundColor[0], backgroundColor[1], backgroundColor[2]));
            }

            return base.CellStyle;
        }
    }
}
