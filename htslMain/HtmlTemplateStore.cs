using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslMain
{
    /// <summary>
    /// Writing inline template to avoid file read/write complexity.
    /// </summary>
    static class HtmlTemplateStore
    {
        public static string SampleTemplate_With_RowStyle
        {
            get
            {
                return @"<html>
                        <head></head>
                        <body>
                            <table>
                            <tr style='width: 10px; height: 20px; background-color: red'>
                            <td>Cell 1</td>
                            <td>Cell 2</td>
                            <td>Cell 3</td>
                            </tr>
                            <tr style='width: 20px; background-color: blue'>
                            <td>Cell 21</td>
                            <td>Cell 22</td>
                            <td>Cell 23</td>
                            <td>Cell 24</td>
                            </tr>
                            </table>
                        </body>
                        </html>";
            }
        }
    }
}
