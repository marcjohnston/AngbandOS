namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class HatOfRegenerationRareItemType : Base2RareItemType
{
    private HatOfRegenerationRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Regeneration";
    public override int Cost => 1500;
    public override string FriendlyName => "of Regeneration";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.HatOfRegeneration;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override bool Regen => true;
    public override int Slot => 33;
}