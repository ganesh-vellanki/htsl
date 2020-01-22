using HtmlAgilityPack;
using htslCore.Internal.Converters;
using htslCore.Internal.Processors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslCore.Main
{
    /// <summary>
    /// HTSL Converter
    /// </summary>
    public class HtslConverter
    {
        /// <summary>
        /// Gets or sets the HTML converter helper.
        /// </summary>
        /// <value>
        /// The HTML converter helper.
        /// </value>
        private HtmlConverterHelper HtmlConverterHelper { get; set; }

        /// <summary>
        /// Gets or sets the excel converter.
        /// </summary>
        /// <value>
        /// The excel converter.
        /// </value>
        private XLConverterHelper XLConverterHelper { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtslConverter" /> class.
        /// </summary>
        public HtslConverter()
        {
            this.HtmlConverterHelper = new HtmlConverterHelper();
            this.XLConverterHelper = new XLConverterHelper();
        }

        /// <summary>
        /// Converts to excel.
        /// </summary>
        /// <param name="htmlString">The HTML string.</param>
        /// <param name="fileName">Name of the file. You can pass null</param>
        /// <returns>
        /// excel file stream as byte array
        /// </returns>
        public byte[] ConvertToExcel(string htmlString, bool processTableStyles = true, string fileName = "Workspace")
        {
            fileName += DateTime.Now.ToString();

            //parse html document into object with html-agility.
            HtmlDocument htmlDocument = this.HtmlConverterHelper.GetNewHtmlDocument(htmlString);

            //load tables from document.
            List<HtmlNode> tableNodes = htmlDocument.DocumentNode.Descendants("table").ToList();
            List<RawStyleSegregator> styleSegregators = new List<RawStyleSegregator>();

            //load excel file.
            this.XLConverterHelper.CreateNewDocument("worksheet" + tableNodes[0].Name + 0);

            //pre-process table styles.
            if(processTableStyles)
            {
                for (int i = 0; i < tableNodes.Count; i++)
                {
                    styleSegregators.Add(new RawStyleSegregator(tableNodes[i]));
                }
            }

            //generate content & set pre-processed styles to excel document.
            for(int i = 0; i < tableNodes.Count; i++)
            {
                XLConverterHelper.GenerateXLContent(tableNodes[i], "worksheet" + tableNodes[0].Name + i);
            }

            //set cell styling
            for (int i = 0; i < tableNodes.Count; i++)
            {
                XLConverterHelper.SetCellStyles(styleSegregators[i], "worksheet" + tableNodes[0].Name + i);
            }

            return XLConverterHelper.GetDocumentInStreamAndClose();
        }
    }
}
