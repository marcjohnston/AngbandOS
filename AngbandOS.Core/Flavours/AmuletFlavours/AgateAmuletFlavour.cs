namespace AngbandOS.Core.Flavours;

[Serializable]
internal class AgateAmuletFlavour : AmuletFlavour
{
    private AgateAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Agate";
}
