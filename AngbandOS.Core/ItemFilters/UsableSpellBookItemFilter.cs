// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an ItemFilter that filters out spellbooks that are of either chosen player Realm.
/// </summary>
internal class UsableSpellBookItemFilter : ItemCategoryItemFilter
{
    public UsableSpellBookItemFilter(SaveGame saveGame) : base()
    {
        if (saveGame.PrimaryRealm != null)
        {
            ItemCategories.Add(saveGame.PrimaryRealm.SpellBookItemCategory);
            if (saveGame.SecondaryRealm != null)
            {
                ItemCategories.Add(saveGame.SecondaryRealm.SpellBookItemCategory);
            }
        }
    }
}
