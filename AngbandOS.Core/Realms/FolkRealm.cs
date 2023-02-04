namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class FolkRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private FolkRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Folk;
        public override string[] Info => new string[] {
            "The Folk realm is the least specialised of all the realms.",
            "Folk magic is capable of doing any effect that is possible", 
            "in other realms - but usually less effectively than the", 
            "specialist realms."
        };
        public override string Name => "Folk";
    }
}
