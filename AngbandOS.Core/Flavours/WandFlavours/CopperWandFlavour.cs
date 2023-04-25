namespace AngbandOS.Core.Flavours;

[Serializable]
internal class CopperWandFlavour : WandFlavour
{
    private CopperWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Copper";
}
