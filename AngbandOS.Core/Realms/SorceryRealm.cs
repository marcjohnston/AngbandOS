namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class SorceryRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private SorceryRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Sorcery;
        public override string[] Info => new string[] {
            "The Sorcery realm contains spells dealing with raw magic",
            "itself, for example spells dealing with magical items.",
            "It is the premier source of miscellaneous non-combat", 
            "utility spells."
     };
    }
}
