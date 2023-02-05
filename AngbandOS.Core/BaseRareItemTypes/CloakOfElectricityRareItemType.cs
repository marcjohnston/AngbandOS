namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class CloakOfElectricityRareItemType : Base2RareItemType
{
    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Cloak of Electricity";
    public override int Cost => 4000;
    public override string FriendlyName => "of Electricity";
    public override bool IgnoreAcid => true;
    public override bool IgnoreElec => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 4;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.CloakOfElectricity;
    public override int Rarity => 0;
    public override int Rating => 16;
    public override bool ResElec => true;
    public override bool ShElec => true;
    public override int Slot => 31;
}
