namespace AngbandOS.Core.Flavours;

[Serializable]
internal class GreenPotionFlavour : PotionFlavour
{
    private GreenPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Green;
    public override string Name => "Green";
}