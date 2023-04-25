namespace AngbandOS.Core.Flavours;

[Serializable]
internal class CopperPlatedWandFlavour : WandFlavour
{
    private CopperPlatedWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Copper-Plated";
}
