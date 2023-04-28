namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class LifeBookItemClass : BookItemFactory
    {
        public LifeBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.LifeBook;
        public override bool HatesFire => true;
        public override int PackSort => 8;
        public override Colour Colour => Colour.BrightWhite;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<LifeRealm>();
    }
}
