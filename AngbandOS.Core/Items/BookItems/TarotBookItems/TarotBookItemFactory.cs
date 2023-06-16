namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class TarotBookItemFactory : BookItemFactory
{
    public TarotBookItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.TarotBook;
    public override int PackSort => 3;
    public override bool HatesFire => true;
    public override Colour Colour => Colour.Pink;
    public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<TarotRealm>();
}
