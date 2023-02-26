namespace AngbandOS.Core.RareItems;

[Serializable]
internal class HatOfUglinessRareItem : RareItem
{
    private HatOfUglinessRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Ugliness";
    public override bool Cha => true;
    public override int Cost => 0;
    public override string FriendlyName => "of Ugliness";
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.HatOfUgliness;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 33;
}
