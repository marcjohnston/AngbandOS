namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class BoltAmmunitionItemFactory : AmmunitionItemClass
{
    public BoltAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bolt;
    public override int PackSort => 33;
    public override Colour Colour => Colour.BrightBrown;

    /// <summary>
    /// Returns true for all bolts.
    /// </summary>
    public override bool KindIsGood => true;


    public override bool HatesAcid => true;
}
