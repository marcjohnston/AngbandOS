namespace AngbandOS.Core.Flavours;

[Serializable]
internal class OilyBlackPotionFlavour : PotionFlavour
{
    private OilyBlackPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Black;
    public override string Name => "Oily Black";
}
