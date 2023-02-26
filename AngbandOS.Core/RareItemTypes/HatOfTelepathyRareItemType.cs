namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class HatOfTelepathyRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Telepathy";
    public override int Cost => 50000;
    public override string FriendlyName => "of Telepathy";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.HatOfTelepathy;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override int Slot => 33;
    public override bool Telepathy => true;
}
