namespace AngbandOS.Core;

[Serializable]
internal class AmmoOfFrostRareItemType : Base2RareItemType
{
    public override char Character => '{';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Ammo of Frost";
    public override bool BrandCold => true;
    public override int Cost => 25;
    public override string FriendlyName => "of Frost";
    public override bool IgnoreCold => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.AmmoOfFrost;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 23;
}
