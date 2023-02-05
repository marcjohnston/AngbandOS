namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class HatOfNaivetyRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Naivety";
    public override int Cost => 0;
    public override string FriendlyName => "of Naivety";
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.HatOfNaivety;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 33;
    public override bool Wis => true;
}
