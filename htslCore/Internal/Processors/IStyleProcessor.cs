using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htslCore.Internal
{
    /// <summary>
    /// Style processor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IStyleProcessor<T>
    {
        /// <summary>
        /// Gets the style.
        /// </summary>
        /// <param name="styleAttr">The style attribute.</param>
        /// <returns>a processed style</returns>
        T GetStyle(string styleAttr);
    }
}
