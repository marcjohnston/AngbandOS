namespace AngbandOS.Core.Flavours;

[Serializable]
internal class CarnelianRingFlavour : RingFlavour
{
    private CarnelianRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Carnelian";
}
