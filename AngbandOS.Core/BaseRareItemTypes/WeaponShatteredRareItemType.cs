using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WeaponShatteredRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon (Shattered)";
    public override int Cost => 0;
    public override string FriendlyName => "(Shattered)";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 5;
    public override int MaxToH => 5;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponShattered;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 24;
}
