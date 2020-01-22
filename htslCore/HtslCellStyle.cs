using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslCore.Model
{
    /// <summary>
    /// HTSL Cell Style
    /// </summary>
    /// <seealso cref="SpreadsheetLight.SLStyle" />
    internal class HtslCellStyle: SLStyle
    {
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>
        /// The color of the background.
        /// </value>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the font weight.
        /// </summary>
        /// <value>
        /// The font weight.
        /// </value>
        public string FontWeight { get; set; }

        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>
        /// The color of the font.
        /// </value>
        public string FontColor { get; set; }

        /// <summary>
        /// Gets or sets the font family.
        /// </summary>
        /// <value>
        /// The font family.
        /// </value>
        public string FontFamily { get; set; }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>
        /// The text align.
        /// </value>
        public string TextAlign { get; set; }

        /// <summary>
        /// Gets or sets the text style.
        /// </summary>
        /// <value>
        /// The text style.
        /// </value>
        public string TextStyle { get; set; }

        /// <summary>
        /// Gets or sets the cell span.
        /// </summary>
        /// <value>
        /// The cell span.
        /// </value>
        public int CellSpan { get; set; }
    }
}
