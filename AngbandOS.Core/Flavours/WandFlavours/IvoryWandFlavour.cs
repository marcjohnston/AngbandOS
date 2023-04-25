namespace AngbandOS.Core.Flavours;

[Serializable]
internal class IvoryWandFlavour : WandFlavour
{
    private IvoryWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Ivory";
}
