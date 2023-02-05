namespace AngbandOS.Core;

[Serializable]
internal class CloakOfProtectionRareItemType : Base2RareItemType
{
    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Cloak of Protection";
    public override int Cost => 500;
    public override string FriendlyName => "of Protection";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 10;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.CloakOfProtection;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 31;
}
