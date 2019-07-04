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
        public static string sampleTemplate1
        {
            get
            {
                return @"<html>
                        <head></head>
                        <body>
                            <table>
                            <tr style='width: 10px; height: 20px'>
                            <td>Cell 1</td>
                            <td>Cell 2</td>
                            <td>Cell 3</td>
                            </tr>
                            </table>
                        </body>
                        </html>";
            }
        }
    }
}
