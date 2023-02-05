namespace AngbandOS.Core;

[Serializable]
internal class HatOfLordlinessRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Lordliness";
    public override bool Cha => true;
    public override int Cost => 2000;
    public override string FriendlyName => "of Lordliness";
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.HatOfLordliness;
    public override int Rarity => 0;
    public override int Rating => 17;
    public override int Slot => 33;
    public override bool SustCha => true;
    public override bool SustWis => true;
    public override bool Wis => true;
}
