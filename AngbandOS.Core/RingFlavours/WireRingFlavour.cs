namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class WireRingFlavour : RingFlavour
{
    private WireRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override string Name => "Wire";
}
