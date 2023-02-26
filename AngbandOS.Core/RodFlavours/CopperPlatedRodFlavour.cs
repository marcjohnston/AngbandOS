namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class CopperPlatedRodFlavour : RodFlavour
{
    private CopperPlatedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Copper-Plated";
}
