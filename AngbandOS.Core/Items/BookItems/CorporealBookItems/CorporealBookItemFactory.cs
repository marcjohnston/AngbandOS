
namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class CorporealBookItemClass : BookItemFactory
    {
        public CorporealBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.CorporealBook;
        public override int PackSort => 1;
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightYellow;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<CorporealRealm>();
    }
}
