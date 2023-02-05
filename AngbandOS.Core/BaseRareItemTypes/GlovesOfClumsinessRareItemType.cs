namespace AngbandOS.Core;

[Serializable]
internal class GlovesOfClumsinessRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Gloves of Clumsiness";
    public override int Cost => 0;
    public override bool Dex => true;
    public override string FriendlyName => "of Clumsiness";
    public override int Level => 0;
    public override int MaxPval => 10;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.GlovesOfClumsiness;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 34;
}
