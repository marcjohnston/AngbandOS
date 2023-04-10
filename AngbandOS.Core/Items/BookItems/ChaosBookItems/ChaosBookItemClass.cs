namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ChaosBookItemClass : BookItemClass
    {
        public ChaosBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.ChaosBook;
        public override int PackSort => 5;
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightRed;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<ChaosRealm>();
    }
}
