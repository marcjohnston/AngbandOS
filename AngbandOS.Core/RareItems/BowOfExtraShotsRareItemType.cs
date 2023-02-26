namespace AngbandOS.Core.RareItems;

[Serializable]
internal class BowOfExtraShotsRareItem : RareItem
{
    private BowOfExtraShotsRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '}';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Bow of Extra Shots";
    public override int Cost => 10000;
    public override string FriendlyName => "of Extra Shots";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 5;
    public override int MaxToH => 10;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.BowOfExtraShots;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override int Slot => 25;
    public override bool XtraShots => true;
}
