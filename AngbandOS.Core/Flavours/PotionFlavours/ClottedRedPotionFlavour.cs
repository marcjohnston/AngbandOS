namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ClottedRedPotionFlavour : PotionFlavour
{
    private ClottedRedPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Red;
    public override string Name => "Clotted Red";
}
