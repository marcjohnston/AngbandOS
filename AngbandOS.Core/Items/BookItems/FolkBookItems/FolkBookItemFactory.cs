namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class FolkBookItemFactory : BookItemClass
    {
        public FolkBookItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.FolkBook;
        public override int PackSort => 2;
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightPurple;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<FolkRealm>();
    }
}
