namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class DeathRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private DeathRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Death;
        public override string[] Info => new string[] {
            "The Death realm has a combination of life-draining spells,",
            "curses, and undead summoning. Like chaos, it is a very",
            "offensive realm."
        };
        public override string Name => "Death";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.DeathBook;
  }
}
