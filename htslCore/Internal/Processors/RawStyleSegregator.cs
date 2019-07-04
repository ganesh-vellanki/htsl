using HtmlAgilityPack;
using htslCore.Main;
using htslCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslCore.Internal.Processors
{
    /// <summary>
    /// Style Segregator
    /// </summary>
    internal class RawStyleSegregator
    {
        /// <summary>
        /// Gets or sets the row style.
        /// </summary>
        /// <value>
        /// The row style.
        /// </value>
        public Dictionary<int, HtslCellStyle> RowStyle { get; set; }

        /// <summary>
        /// Gets or sets the cell style.
        /// </summary>
        /// <value>
        /// The cell style.
        /// </value>
        public Dictionary<string, HtslCellStyle> ColStyle { get; set; }

        /// <summary>
        /// Gets or sets the style affixer.
        /// </summary>
        /// <value>
        /// The style affixer.
        /// </value>
        public StyleAffixer StyleAffixer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RawStyleSegregator"/> class.
        /// </summary>
        public RawStyleSegregator()
        {
            this.StyleAffixer = new StyleAffixer();
            this.RowStyle = new Dictionary<int, HtslCellStyle>();
            this.ColStyle = new Dictionary<string, HtslCellStyle>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RawStyleSegregator"/> class.
        /// </summary>
        public RawStyleSegregator(HtmlNode htmlNode)
            :this()
        {
            this.ProcessRowStyles(htmlNode);
        }

        /// <summary>
        /// Processes the row styles.
        /// </summary>
        /// <param name="htmlNode">The HTML node.</param>
        private void ProcessRowStyles(HtmlNode htmlNode)
        {
            var rows = htmlNode.Descendants("tr").ToList();
            for (int i = 0; i < rows.Count; i++)
            {
                var styleAttribute = rows[i].GetAttributeValue("style", null);
                if(styleAttribute != null)
                {
                    this.RowStyle.Add(i, this.ProcessStyleProperties(styleAttribute));
                    this.ProcessColStyles(htmlNode, i);
                }
            }
        }

        /// <summary>
        /// Processes the col styles.
        /// </summary>
        /// <param name="htmlNode">The HTML node.</param>
        private void ProcessColStyles(HtmlNode htmlNode, int rowIndex)
        {
            var cols = htmlNode.Descendants("td").ToList();
            for (int i = 0; i < cols.Count; i++)
            {
                var styleAttribute = cols[i].GetAttributeValue("style", null);
                if(styleAttribute != null)
                {
                    this.ColStyle.Add(string.Format(HtslConstants.RowColPlaceHolder, rowIndex, i), this.ProcessStyleProperties(styleAttribute));
                }
            }
        }

        /// <summary>
        /// Processes the style properties.
        /// </summary>
        /// <param name="styleStr">The style string.</param>
        /// <returns></returns>
        private HtslCellStyle ProcessStyleProperties(string styleStr)
        {
            string[] cssProperties = styleStr.Split(';');
            HtslCellStyle cellStyle = new HtslCellStyle();

            var styleLookup = this.ConvertStylesAsDictionary(styleStr);

            //Process the styles with styleAffixer.
            this.StyleAffixer
                .BindStyle(new BackgroundColorStyleProcessor(cellStyle), styleLookup.ContainsKey(HtslConstants.CssBackgroundColor) ? styleLookup[HtslConstants.CssBackgroundColor]: null)
                .BindStyle(new BorderStyleProcessor(cellStyle), styleLookup.ContainsKey(HtslConstants.CssBorder) ? styleLookup[HtslConstants.CssBorder] : null);

            return cellStyle;
        }

        /// <summary>
        /// Converts the styles as dictionary.
        /// </summary>
        /// <param name="styleString">The style string.</param>
        /// <returns>Dictionary form of styles.</returns>
        private IDictionary<string, string> ConvertStylesAsDictionary(string styleString)
        {
            IDictionary<string, string> styleLookup = new Dictionary<string, string>();
            var kvPairStrings = styleString.Split(';');

            for (int i = 0; i < kvPairStrings.Length; i++)
            {
                var splitKeyValuePair = kvPairStrings[i].Trim().Split(':');
                var key = splitKeyValuePair[0].Trim();
                if (styleLookup.ContainsKey(key))
                {
                    styleLookup[key] = splitKeyValuePair[1].Trim();
                }
                else
                {
                    styleLookup.Add(key, splitKeyValuePair[1].Trim());
                }
            }

            return styleLookup;
        }
    }
}
