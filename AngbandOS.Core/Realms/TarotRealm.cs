namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class TarotRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private TarotRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Tarot;
        public override string[] Info => new string[] {
            "The Tarot realm is one of the most specialised realms of", 
            "all, almost exclusively containing summoning and transport", 
            "spells."
       };
    }
}
