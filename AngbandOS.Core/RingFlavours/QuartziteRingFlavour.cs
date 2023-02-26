namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class QuartziteRingFlavour : RingFlavour
{
    private QuartziteRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Quartzite";
}
