namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ShotAmmunitionItemFactory : AmmunitionItemClass
{
    public ShotAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Shot;
    public override int PackSort => 35;
    public override Colour Colour => Colour.BrightBrown;
}
