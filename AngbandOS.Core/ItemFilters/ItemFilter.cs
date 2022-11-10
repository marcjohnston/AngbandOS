using AngbandOS.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an interface that an object must implement to handle ItemFiltering.  ItemFilters and stores implement this interface.
    /// </summary>
    internal interface IItemFilter
    {
        /// <summary>
        /// Returns whether or not an item matches the desired filter.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ItemMatches(Item item);
    }

    /// <summary>
    /// Represents an object that performs item filtering.
    /// </summary>
    internal class ItemFilter : IItemFilter
    {
        /// <inheritdoc/>
        /// <returns>Returns true, by default, so that all items quality.</returns>
        public virtual bool ItemMatches(Item item) => true;
    }

    /// <summary>
    /// Represents an ItemFilter object that returns true, if an Item is of any specific ItemCategory.
    /// </summary>
    internal class ItemCategoryItemFilter : ItemFilter
    {
        public override bool ItemMatches(Item item)
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
    /// Represents an ItemFilter that filters out spellbooks that are of either chosen player Realm.
    /// </summary>
    internal class UsableSpellBookItemFilter : ItemCategoryItemFilter
    {
        public UsableSpellBookItemFilter(SaveGame saveGame) : base(saveGame.Player.Realm1.ToSpellBookItemCategory(), saveGame.Player.Realm2.ToSpellBookItemCategory())
        {
        }
    }

    /// <summary>
    /// Represents an ItemFilter that filters out items that can be activated.
    /// </summary>
    internal class ActivatableItemFilter : ItemFilter
    {
        public override bool ItemMatches(Item item)
        {
            if (!item.IsKnown())
            {
                return false;
            }
            item.RefreshFlagBasedProperties();
            return item.Characteristics.Activate;
        }
    }

    /// <summary>
    /// Represents an ItemFilter that filters out weapons.
    /// </summary>
    internal class WeaponItemFilter : ItemCategoryItemFilter
    {
        public WeaponItemFilter() : base(ItemCategory.Sword, ItemCategory.Hafted, ItemCategory.Polearm, ItemCategory.Digging, ItemCategory.Bow, ItemCategory.Bolt, ItemCategory.Arrow, ItemCategory.Shot)
        {
        }
    }

    /// <summary>
    /// Represents an ItemFilter that filters out armour items.
    /// </summary>
    internal class ArmourItemFilter : ItemCategoryItemFilter
    {
        public ArmourItemFilter() : base(ItemCategory.DragArmor, ItemCategory.HardArmor, ItemCategory.SoftArmor, ItemCategory.Shield, ItemCategory.Cloak, ItemCategory.Crown, ItemCategory.Helm, ItemCategory.Boots, ItemCategory.Gloves)
        {
        }
    }

    /// <summary>
    /// Represents an ItemFilter that filters out items that can fuel a lantern.
    /// </summary>
    internal class LanternFuelItemFilter : ItemFilter
    {
        public override bool ItemMatches(Item item)
        {
            if (item.Category == ItemCategory.Flask)
            {
                return true;
            }
            if (item.Category == ItemCategory.Light && item.ItemSubCategory == LightType.Lantern)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Represents an ItemFilter that filters items that can fuel a torch.
    /// </summary>
    internal class TorchFuelItemFilter : ItemFilter
    {
        public override bool ItemMatches(Item item)
        {
            return item.Category == ItemCategory.Light && item.ItemSubCategory == LightType.Torch;
        }
    }

    /// <summary>
    /// Represents an ItemFilter that filters items that can be worn or wielded.
    /// </summary>
    internal class WearableItemFilter : ItemCategoryItemFilter
    {
        public WearableItemFilter() : base(ItemCategory.DragArmor, ItemCategory.HardArmor, ItemCategory.SoftArmor, ItemCategory.Shield, ItemCategory.Cloak, ItemCategory.Crown, ItemCategory.Helm, ItemCategory.Boots, ItemCategory.Gloves, ItemCategory.Sword, ItemCategory.Hafted, ItemCategory.Polearm, ItemCategory.Digging, ItemCategory.Bow, ItemCategory.Ring, ItemCategory.Amulet, ItemCategory.Light)
        {
        }
    }

    internal class RechargableItemFilter : ItemCategoryItemFilter
    {
        public RechargableItemFilter() : base(ItemCategory.Staff, ItemCategory.Wand, ItemCategory.Rod)
        {
        }
    }
}
