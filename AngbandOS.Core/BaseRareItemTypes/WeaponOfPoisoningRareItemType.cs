using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfPoisoningRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Poisoning";
    public override bool BrandPois => true;
    public override int Cost => 4500;
    public override string FriendlyName => "of Poisoning";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponOfPoisoning;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override bool ResPois => true;
    public override int Slot => 24;
}
