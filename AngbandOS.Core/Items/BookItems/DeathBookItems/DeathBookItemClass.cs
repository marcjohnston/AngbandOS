namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class DeathBookItemClass : BookItemClass
    {
        public DeathBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.DeathBook;
        public override bool HatesFire => true;
        public override int PackSort => 4;
        public override Colour Colour => Colour.Black;

        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<DeathRealm>();
    }
}
