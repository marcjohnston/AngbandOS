namespace AngbandOS.Core.RareItems;

[Serializable]
internal class HatOfMightRareItem : RareItem
{
    private HatOfMightRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Might";
    public override bool Con => true;
    public override int Cost => 2000;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Might";
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.HatOfMight;
    public override int Rarity => 0;
    public override int Rating => 19;
    public override int Slot => 33;
    public override bool Str => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustStr => true;
}
