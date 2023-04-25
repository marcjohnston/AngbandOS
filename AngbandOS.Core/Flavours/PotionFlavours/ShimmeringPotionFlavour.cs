namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ShimmeringPotionFlavour : PotionFlavour
{
    private ShimmeringPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Shimmering";
}
