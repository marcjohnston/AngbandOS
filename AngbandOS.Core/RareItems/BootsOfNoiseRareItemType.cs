namespace AngbandOS.Core.RareItems;

[Serializable]
internal class BootsOfNoiseRareItem : RareItem
{
    private BootsOfNoiseRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Boots of Noise";
    public override bool Aggravate => true;
    public override int Cost => 0;
    public override string FriendlyName => "of Noise";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.BootsOfNoise;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 35;
}