namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class AmethystRingFlavour : RingFlavour
{
    private AmethystRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Amethyst";
}
