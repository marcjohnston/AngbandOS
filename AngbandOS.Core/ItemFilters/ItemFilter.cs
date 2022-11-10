using AngbandOS.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngbandOS.Core.ItemFilters
{
    internal class ItemFilter
    {
        /// <summary>
        /// Returns whether or not an item conforms to some rule.  Returns true, by defalt.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool Matches(Item item) => true;
    }

    /// <summary>
    /// Represents an ItemFilter object that returns true, if an Item is of a specific ItemCategory.
    /// </summary>
    internal class ItemCategoryItemFilter : ItemFilter
    {
        public override bool Matches(Item item)
        {
            return item.Category == ItemCategory;
        }

        private ItemCategory ItemCategory { get; }

        public ItemCategoryItemFilter(ItemCategory itemCategory)
        {
            ItemCategory = itemCategory;
        }
    }
}
