using htslCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslCore.Internal.Processors
{
    /// <summary>
    /// Style Processor
    /// </summary>
    /// <seealso cref="htslCore.Internal.IStyleProcessor{htslCore.Model.HtslCellStyle}" />
    internal abstract class StyleProcessor
    {
        /// <summary>
        /// Gets or sets the cell style.
        /// </summary>
        /// <value>
        /// The cell style.
        /// </value>
        public HtslCellStyle CellStyle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleProcessor"/> class.
        /// </summary>
        public StyleProcessor(HtslCellStyle cellStyle)
        {
            this.CellStyle = cellStyle;
        }
    }
}
