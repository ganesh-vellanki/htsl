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
        /// Gets or sets the raw style lookup. Volatile property.
        /// </summary>
        /// <value>
        /// The raw style lookup.
        /// </value>
        public IDictionary<string, string> RawStyleLookup { get; set; }

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
            this.RawStyleLookup = new Dictionary<string, string>();
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

                if(!string.IsNullOrEmpty(styleAttribute))
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
            HtslCellStyle cellStyle = new HtslCellStyle();

            this.GenerateRawStyleLookup(styleStr);

            //Process the styles with styleAffixer.
            this.StyleAffixer
                .BindStyle(new BackgroundColorStyleProcessor(cellStyle), this.GetStyleValueForProperty(HtslConstants.CssBackgroundColor))
                .BindStyle(new BorderStyleProcessor(cellStyle), this.GetStyleValueForProperty(HtslConstants.CssBorder));

            return cellStyle;
        }

        /// <summary>
        /// Converts the styles for lookup.
        /// </summary>
        /// <param name="styleString">The style string.</param>
        /// <returns>Dictionary form of styles.</returns>
        private void GenerateRawStyleLookup(string styleString)
        {
            this.RawStyleLookup.Clear();

            var kvPairStrings = styleString.Split(';');

            for (int i = 0; i < kvPairStrings.Length; i++)
            {
                var splitKeyValuePair = kvPairStrings[i].Trim().Split(':');

                var key = splitKeyValuePair[0].Trim();

                if (this.RawStyleLookup.ContainsKey(key))
                {
                    this.RawStyleLookup[key] = splitKeyValuePair[1].Trim();
                }
                else
                {
                    this.RawStyleLookup.Add(key, splitKeyValuePair[1].Trim());
                }
            }
        }

        /// <summary>
        /// Gets the style value for property.
        /// </summary>
        /// <param name="styleKey">The style key.</param>
        /// <returns>
        /// Style Value
        /// </returns>
        private string GetStyleValueForProperty(string styleKey)
        {
            return this.RawStyleLookup != null && this.RawStyleLookup.ContainsKey(styleKey) ? this.RawStyleLookup[styleKey] : null;
        }
    }
}
