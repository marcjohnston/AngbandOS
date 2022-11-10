namespace AngbandOS.Core.ItemFilters
{
    /// <summary>
    /// Represents an ItemFilter that filters out spellbooks that are of either chosen player Realm.
    /// </summary>
    internal class UsableSpellBookItemFilter : ItemCategoryItemFilter
    {
        public UsableSpellBookItemFilter(SaveGame saveGame) : base(saveGame.Player.Realm1.ToSpellBookItemCategory(), saveGame.Player.Realm2.ToSpellBookItemCategory())
        {
        }
    }
}
