namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class WeaponOfShockingRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Shocking";
    public override bool BrandElec => true;
    public override int Cost => 4500;
    public override string FriendlyName => "of Shocking";
    public override bool IgnoreElec => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfShocking;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override bool ResElec => true;
    public override int Slot => 24;
}
