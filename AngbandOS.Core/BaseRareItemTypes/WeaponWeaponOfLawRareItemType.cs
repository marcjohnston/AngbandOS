using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WeaponWeaponOfLawRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon (Weapon of Law)";
    public override bool Con => true;
    public override int Cost => 25000;
    public override bool FreeAct => true;
    public override string FriendlyName => "(Weapon of Law)";
    public override int Level => 0;
    public override int MaxPval => 2;
    public override int MaxToA => 0;
    public override int MaxToD => 6;
    public override int MaxToH => 6;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponOfLaw;
    public override int Rarity => 0;
    public override int Rating => 26;
    public override bool SeeInvis => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override int Slot => 24;
    public override bool Str => true;
}
