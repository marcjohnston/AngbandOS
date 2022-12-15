using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfSharpnessRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Sharpness";
    public override int Cost => 5000;
    public override string FriendlyName => "of Sharpness";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponOfSharpness;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override int Slot => 24;
    public override bool Tunnel => true;
    public override bool Vorpal => true;
}
