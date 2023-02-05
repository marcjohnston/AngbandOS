namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class WeaponDefenderRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon (Defender)";
    public override int Cost => 15000;
    public override bool Feather => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "(Defender)";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 4;
    public override int MaxToA => 8;
    public override int MaxToD => 4;
    public override int MaxToH => 4;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponDefender;
    public override int Rarity => 0;
    public override int Rating => 25;
    public override bool Regen => true;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override int Slot => 24;
    public override bool Stealth => true;
}
