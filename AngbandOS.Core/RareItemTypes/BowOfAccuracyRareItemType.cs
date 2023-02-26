namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class BowOfAccuracyRareItemType : Base2RareItemType
{
    private BowOfAccuracyRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '}';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Bow of Accuracy";
    public override int Cost => 1000;
    public override string FriendlyName => "of Accuracy";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 5;
    public override int MaxToH => 15;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.BowOfAccuracy;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 25;
}
