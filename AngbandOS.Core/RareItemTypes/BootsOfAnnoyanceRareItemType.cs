namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class BootsOfAnnoyanceRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Boots of Annoyance";
    public override bool Aggravate => true;
    public override int Cost => 0;
    public override string FriendlyName => "of Annoyance";
    public override int Level => 0;
    public override int MaxPval => 10;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.BootsOfAnnoyance;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 35;
    public override bool Speed => true;
}
