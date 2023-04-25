namespace AngbandOS.Core.Flavours;

[Serializable]
internal class IvoryAmuletFlavour : AmuletFlavour
{
    private IvoryAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Ivory";
}
