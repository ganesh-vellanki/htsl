using HtmlAgilityPack;
using htslCore.Internal.Processors;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslCore.Internal.Converters
{
    /// <summary>
    /// excel converter helper
    /// </summary>
    internal class XLConverterHelper
    {
        /// <summary>
        /// Gets or sets the sl document.
        /// </summary>
        /// <value>
        /// The sl document.
        /// </value>
        public SLDocument SLDocument { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XLConverterHelper"/> class.
        /// </summary>
        public XLConverterHelper()
        {
            this.SLDocument = null;
        }

        /// <summary>
        /// Gets the new document.
        /// </summary>
        /// <param name="workspaceName">Name of the workspace.</param>
        /// <returns>
        /// sl document
        /// </returns>
        public bool CreateNewDocument(string workspaceName)
        {
            this.SLDocument = new SLDocument();
            this.SLDocument.RenameWorksheet(this.SLDocument.GetCurrentWorksheetName(), workspaceName);
            return true;
        }

        /// <summary>
        /// Generates the content of the xl.
        /// </summary>
        /// <param name="htmlNode">The HTML node.</param>
        public void GenerateXLContent(HtmlNode htmlNode, string workSheetName)
        {
            this.SetCurrentWorkSheet(workSheetName);
            var rows = htmlNode.Descendants("tr").ToList();

            for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
            {
                var cols = rows[rowIndex].Descendants("td").ToList();

                for (int colIndex = 0; colIndex < cols.Count; colIndex++)
                {
                    this.SLDocument.SetCellValue(rowIndex, colIndex, cols[colIndex].InnerText);
                }
            }
        }

        /// <summary>
        /// Sets the cell styles.
        /// </summary>
        /// <param name="rawStyleSegregator">The raw style segregator.</param>
        /// <param name="worksheetName">Name of the worksheet.</param>
        public void SetCellStyles(RawStyleSegregator rawStyleSegregator, string worksheetName)
        {
            this.SetCurrentWorkSheet(worksheetName);
        }

        /// <summary>
        /// Saves the document in stream and close.
        /// </summary>
        /// <param name="memoryStream">The memory stream.</param>
        /// <remarks>Document will be disposed after this method is called.</remarks>
        /// <returns>Filled memory stream</returns>
        public byte[] GetDocumentInStreamAndClose()
        {
            byte[] xlResult = null;

            using (var stream = new MemoryStream())
            {
                this.SLDocument.SaveAs(stream);
                this.SLDocument.Dispose();
                this.SLDocument = null;
                xlResult = stream.ToArray();
            }

            return xlResult;
        }

        /// <summary>
        /// Sets the name of the current work sheet.
        /// </summary>
        /// <param name="workSheetName">Name of the work sheet.</param>
        private void SetCurrentWorkSheet(string workSheetName)
        {
            if(this.SLDocument.GetWorksheetNames().Any(x => string.Compare(x, workSheetName, true) == 0))
            {
                this.SLDocument.SelectWorksheet(workSheetName);
            }
            else
            {
                this.SLDocument.AddWorksheet(workSheetName);
                this.SLDocument.SelectWorksheet(workSheetName);
            }
        }
    }
}
