namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class BootsOfSpeedRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Boots of Speed";
    public override int Cost => 200000;
    public override string FriendlyName => "of Speed";
    public override bool HideType => true;
    public override int Level => 0;
    public override int MaxPval => 10;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.BootsOfSpeed;
    public override int Rarity => 0;
    public override int Rating => 25;
    public override int Slot => 35;
    public override bool Speed => true;
}
