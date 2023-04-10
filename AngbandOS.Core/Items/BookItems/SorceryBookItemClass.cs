namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class SorceryBookItemClass : BookItemClass
    {
        public SorceryBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SorceryBook;
        public override bool HatesFire => true;
        public override int PackSort => 7;
        public override Colour Colour => Colour.BrightBlue;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<SorceryRealm>();
    }
}
