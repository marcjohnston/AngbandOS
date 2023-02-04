namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class LifeRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private LifeRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Life;
        public override string[] Info => new string[] {
            "The Life realm is devoted to healing and buffing, with some", 
            "offensive capability against undead and demons. It is the", 
            "most defensive of the realms."
      };
        public override string Name => "Life";

        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.LifeBook;
    }
}
