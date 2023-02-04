namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter that filters out spellbooks that are of either chosen player Realm.
    /// </summary>
    internal class UsableSpellBookItemFilter : ItemCategoryItemFilter
    {
        public UsableSpellBookItemFilter(SaveGame saveGame) : base()
        {
            if (saveGame.Player.PrimaryRealm != null)
            {
                ItemCategories.Add(saveGame.Player.PrimaryRealm.SpellBookItemCategory);
                if (saveGame.Player.SecondaryRealm != null)
                {
                    ItemCategories.Add(saveGame.Player.SecondaryRealm.SpellBookItemCategory);
                }
            }
        }
    }
}
