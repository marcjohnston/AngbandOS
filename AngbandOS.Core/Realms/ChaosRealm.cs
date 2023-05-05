namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class ChaosRealm : BaseRealm
    {
        private ChaosRealm(SaveGame savedGame) : base(savedGame) { }

        public override string[] Info => new string[] {
            "The Chaos realm is the most destructive realm. It focuses",
            "on combat spells. It is a very good choice for anyone who",
            "wants to be able to damage their foes directly, but is ",
            "somewhat lacking in non-combat spells."
        };

        public override string Name => "Chaos";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.ChaosBook;

        /// <summary>
        /// Returns the Sign Of Chaos, Mastery Chaos, Gharne Fragments and Azathoth Chaos books because they belong to the Chaos realm.
        /// </summary>
        public override BookItemFactory[] SpellBooks => new BookItemFactory[]
        {
            SaveGame.SingletonRepository.ItemFactories.Get<SignOfChaosChaosBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<MasteryChaosBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<GharneFragmentsChaosBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<AzathothChaosBookItemFactory>()
        };
    }
}
