// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an ItemFilter that filters items that can be worn or wielded.
/// </summary>
internal class WearableItemFilter : ItemCategoryItemFilter
{
    public WearableItemFilter() : base(ItemTypeEnum.DragArmor, ItemTypeEnum.HardArmor, ItemTypeEnum.SoftArmor, ItemTypeEnum.Shield, ItemTypeEnum.Cloak, ItemTypeEnum.Crown, ItemTypeEnum.Helm, ItemTypeEnum.Boots, ItemTypeEnum.Gloves, ItemTypeEnum.Sword, ItemTypeEnum.Hafted, ItemTypeEnum.Polearm, ItemTypeEnum.Digging, ItemTypeEnum.Bow, ItemTypeEnum.Ring, ItemTypeEnum.Amulet, ItemTypeEnum.Light)
    {
    }
}
