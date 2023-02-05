namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class OrbOfClarityRareItemType : Base2RareItemType
{
    public override char Character => '~';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Orb of Clarity";
    public override int Cost => 1000;
    public override string FriendlyName => "of Clarity";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.OrbOfClarity;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override bool ResConf => true;
    public override int Slot => 0;
}
