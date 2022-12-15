using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfBurningRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Burning";
    public override bool BrandFire => true;
    public override int Cost => 3000;
    public override string FriendlyName => "of Burning";
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override bool Lightsource => true;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponOfBurning;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override bool ResFire => true;
    public override int Slot => 24;
}
