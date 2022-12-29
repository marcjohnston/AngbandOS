namespace AngbandOS.Core;

[Serializable]
internal class BowOfExtraMightRareItemType : Base2RareItemType
{
    public override char Character => '}';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Bow of Extra Might";
    public override int Cost => 10000;
    public override string FriendlyName => "of Extra Might";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 10;
    public override int MaxToH => 5;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.BowOfExtraMight;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override int Slot => 25;
    public override bool XtraMight => true;
}
