// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an ItemFilter that filters out armour items.
/// </summary>
internal class ArmourItemFilter : ItemCategoryItemFilter
{
    public ArmourItemFilter() : base(ItemTypeEnum.DragArmor, ItemTypeEnum.HardArmor, ItemTypeEnum.SoftArmor, ItemTypeEnum.Shield, ItemTypeEnum.Cloak, ItemTypeEnum.Crown, ItemTypeEnum.Helm, ItemTypeEnum.Boots, ItemTypeEnum.Gloves)
    {
    }
}
