namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class HatOfBeautyRareItemType : Base2RareItemType
{
    private HatOfBeautyRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Beauty";
    public override bool Cha => true;
    public override int Cost => 1000;
    public override string FriendlyName => "of Beauty";
    public override int Level => 0;
    public override int MaxPval => 4;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.HatOfBeauty;
    public override int Rarity => 0;
    public override int Rating => 8;
    public override int Slot => 33;
    public override bool SustCha => true;
}
