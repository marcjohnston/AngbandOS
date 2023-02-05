namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfUndeadBaneRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Undead Bane";
    public override int Cost => 8000;
    public override string FriendlyName => "of Undead Bane";
    public override int Level => 0;
    public override int MaxPval => 2;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.WeaponOfUndeadBane;
    public override int Rarity => 0;
    public override int Rating => 24;
    public override bool SeeInvis => true;
    public override bool SlayUndead => true;
    public override int Slot => 24;
    public override bool Wis => true;
}
