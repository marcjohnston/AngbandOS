namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class CorporealRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private CorporealRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Corporeal;
    }
}
