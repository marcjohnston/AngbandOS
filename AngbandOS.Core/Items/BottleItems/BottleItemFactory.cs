namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class BottleItemFactory : ItemFactory
{
    public BottleItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override bool EasyKnow => true;
    public override int PackSort => 39;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bottle;
    public override bool HatesCold => true;
    public override bool HatesAcid => true;

}
