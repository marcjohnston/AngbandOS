namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class ChaosRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private ChaosRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Chaos;

        public override string[] Info => new string[] {
            "The Chaos realm is the most destructive realm. It focuses",
            "on combat spells. It is a very good choice for anyone who",
            "wants to be able to damage their foes directly, but is ",
            "somewhat lacking in non-combat spells."
        };
    }
}
