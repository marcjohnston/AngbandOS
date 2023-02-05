namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class CloakOfImmolationRareItemType : Base2RareItemType
{
    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Cloak of Immolation";
    public override int Cost => 4000;
    public override string FriendlyName => "of Immolation";
    public override bool IgnoreAcid => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 4;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.CloakOfImmolation;
    public override int Rarity => 0;
    public override int Rating => 16;
    public override bool ResFire => true;
    public override bool ShFire => true;
    public override int Slot => 31;
}
