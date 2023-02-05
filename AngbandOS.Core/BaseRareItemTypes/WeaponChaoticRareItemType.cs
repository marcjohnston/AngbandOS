namespace AngbandOS.Core;

[Serializable]
internal class WeaponChaoticRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon (Chaotic)";
    public override bool Chaotic => true;
    public override int Cost => 10000;
    public override string FriendlyName => "(Chaotic)";
    public override bool IgnoreAcid => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponChaotic;
    public override int Rarity => 0;
    public override int Rating => 28;
    public override bool ResChaos => true;
    public override int Slot => 24;
}
