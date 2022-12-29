namespace AngbandOS.Core;

[Serializable]
internal class BootsWingedRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Boots (Winged)";
    public override int Cost => 250;
    public override bool Feather => true;
    public override string FriendlyName => "(Winged)";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.BootsWinged;
    public override int Rarity => 0;
    public override int Rating => 7;
    public override int Slot => 35;
}
