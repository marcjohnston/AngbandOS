namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BrownPotionFlavour : PotionFlavour
{
    private BrownPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Brown";
}
