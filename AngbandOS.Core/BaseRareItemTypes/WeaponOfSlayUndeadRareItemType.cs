using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfSlayUndeadRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Slay Undead";
    public override int Cost => 3500;
    public override string FriendlyName => "of Slay Undead";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponOfSlayUndead;
    public override int Rarity => 0;
    public override int Rating => 18;
    public override bool SlayUndead => true;
    public override int Slot => 24;
}
