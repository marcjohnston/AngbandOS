namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SorceryBookItem : BookItem
    {
        public SorceryBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        protected override string RealmName => "Sorcery";

        /// <summary>
        /// Returns just the realm name because Sorcery automatically assumes magic--so we omit the "Magic" suffix from the divine title.
        /// </summary>
        protected override string DivineTitle => RealmName;
    }
}