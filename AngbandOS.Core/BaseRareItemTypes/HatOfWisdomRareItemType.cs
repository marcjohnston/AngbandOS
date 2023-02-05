namespace AngbandOS.Core;

[Serializable]
internal class HatOfWisdomRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Wisdom";
    public override int Cost => 500;
    public override string FriendlyName => "of Wisdom";
    public override int Level => 0;
    public override int MaxPval => 2;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.HatOfWisdom;
    public override int Rarity => 0;
    public override int Rating => 13;
    public override int Slot => 33;
    public override bool SustWis => true;
    public override bool Wis => true;
}
