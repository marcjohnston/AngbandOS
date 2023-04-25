namespace AngbandOS.Core.Flavours;

[Serializable]
internal class LightGreenPotionFlavour : PotionFlavour
{
    private LightGreenPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Light Green";
}
