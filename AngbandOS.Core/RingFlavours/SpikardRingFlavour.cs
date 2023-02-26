namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class SpikardRingFlavour : RingFlavour
{
    private SpikardRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Spikard";
}
