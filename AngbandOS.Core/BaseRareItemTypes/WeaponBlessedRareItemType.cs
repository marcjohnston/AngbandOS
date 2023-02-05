namespace AngbandOS.Core;

[Serializable]
internal class WeaponBlessedRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon (Blessed)";
    public override bool Blessed => true;
    public override int Cost => 5000;
    public override string FriendlyName => "(Blessed)";
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.WeaponBlessed;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override int Slot => 24;
    public override bool Wis => true;
}
