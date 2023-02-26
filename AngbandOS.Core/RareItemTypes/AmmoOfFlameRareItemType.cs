namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class AmmoOfFlameRareItemType : Base2RareItemType
{
    public override char Character => '{';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Ammo of Flame";
    public override bool BrandFire => true;
    public override int Cost => 30;
    public override string FriendlyName => "of Flame";
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.AmmoOfFlame;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 23;
}
