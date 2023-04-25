namespace AngbandOS.Core.Flavours;

[Serializable]
internal class OilyYellowPotionFlavour : PotionFlavour
{
    private OilyYellowPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Oily Yellow";
}
