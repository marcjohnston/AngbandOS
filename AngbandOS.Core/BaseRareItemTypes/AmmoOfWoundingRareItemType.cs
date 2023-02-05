namespace AngbandOS.Core;

[Serializable]
internal class AmmoOfWoundingRareItemType : Base2RareItemType
{
    public override char Character => '{';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Ammo of Wounding";
    public override int Cost => 20;
    public override string FriendlyName => "of Wounding";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 6;
    public override int MaxToH => 6;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.AmmoOfWounding;
    public override int Rarity => 0;
    public override int Rating => 5;
    public override int Slot => 23;
}
