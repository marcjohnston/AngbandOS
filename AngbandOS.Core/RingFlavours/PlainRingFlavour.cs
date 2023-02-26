namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class PlainRingFlavour : RingFlavour
{
    private PlainRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override string Name => "Plain";
}
