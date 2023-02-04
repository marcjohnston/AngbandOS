namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class NatureRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private NatureRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Nature;
        public override string[] Info => new string[] {
            "The Nature realm has a large number of summoning spells and",
            "miscellaneous spells, but little in the way of offensive", 
            "and defensive capabilities."
      };
    }
}
