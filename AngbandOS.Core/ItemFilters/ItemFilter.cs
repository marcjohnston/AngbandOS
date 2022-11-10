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
    /// Represents an ItemFilter object that returns true, if an Item is of any specific ItemCategory.
    /// </summary>
    internal class ItemCategoryItemFilter : ItemFilter
    {
        public override bool Matches(Item item)
        {
            foreach (ItemCategory itemCategory in ItemCategories)
            {
                if (item.Category == itemCategory)
                    return true;
            }
            return false;
        }

        private ItemCategory[] ItemCategories { get; }

        public ItemCategoryItemFilter(params ItemCategory[] itemCategories)
        {
            ItemCategories = itemCategories;
        }
    }

    /// <summary>
    /// Represents an ItemFilter that filters out all items that are not of either chosen player Realm.
    /// </summary>
    internal class UsableSpellBookItemFilter : ItemCategoryItemFilter
    {
        public UsableSpellBookItemFilter(SaveGame saveGame) : base(saveGame.Player.Realm1.ToSpellBookItemCategory(), saveGame.Player.Realm2.ToSpellBookItemCategory())
        {
        }
    }
}
