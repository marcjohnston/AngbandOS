namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class CorporealRealm : BaseRealm
    {
        private CorporealRealm(SaveGame savedGame) : base(savedGame) { }

        public override string[] Info => new string[] {
            "The Corporeal realm contains spells that exclusively affect",
            "the caster's body, although some spells also indirectly",
            "affect other creatures or objects. The corporeal realm is",
            "particularly good at sensing spells."
       };

        /// <summary>
        /// Returns the Basic Chi, Yogic Mastery, DeVermis Mysteriis and Pnakotic Manuscript books because they belong to the Corporeal realm.
        /// </summary>
        public override BookItemFactory[] SpellBooks => new BookItemFactory[]
        {
            SaveGame.SingletonRepository.ItemFactories.Get<BasicChiFlowCorporealBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<YogicMasteryCorporealBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<DeVermisMysteriisCorporealBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<PnakoticManuscriptsCorporealBookItemFactory>()
        };

        public override string Name => "Corporeal";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.CorporealBook;
    }
}
