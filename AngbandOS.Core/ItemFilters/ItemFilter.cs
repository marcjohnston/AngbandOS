using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an object that performs item filtering.
    /// </summary>
    internal abstract class ItemFilter : IItemFilter
    {
        /// <inheritdoc/>
        public abstract bool ItemMatches(Item item);
    }
}
