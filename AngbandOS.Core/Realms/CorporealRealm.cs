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
        public override string[] Info => new string[] {
            "The Corporeal realm contains spells that exclusively affect",
            "the caster's body, although some spells also indirectly",
            "affect other creatures or objects. The corporeal realm is",
            "particularly good at sensing spells."
       };
    }
}
