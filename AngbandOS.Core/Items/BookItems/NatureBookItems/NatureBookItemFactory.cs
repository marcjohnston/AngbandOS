namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class NatureBookItemFactory : BookItemFactory
{
    public NatureBookItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.NatureBook;

    public override int PackSort => 6;
    public override bool HatesFire => true;
    public override Colour Colour => Colour.BrightGreen;
    public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<NatureRealm>();
}
