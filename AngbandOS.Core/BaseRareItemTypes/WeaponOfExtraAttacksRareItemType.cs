using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfExtraAttacksRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Extra Attacks";
    public override bool Blows => true;
    public override int Cost => 10000;
    public override string FriendlyName => "of Extra Attacks";
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponOfExtraAttacks;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override int Slot => 24;
}
