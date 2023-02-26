namespace AngbandOS.Core.RareItems;

[Serializable]
internal class BowOfVelocityRareItem : RareItem
{
    private BowOfVelocityRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '}';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Bow of Velocity";
    public override int Cost => 1000;
    public override string FriendlyName => "of Velocity";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 15;
    public override int MaxToH => 5;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.BowOfVelocity;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 25;
}
