namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class DriftwoodAmuletFlavour : AmuletFlavour
{
    private DriftwoodAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Driftwood";
}
