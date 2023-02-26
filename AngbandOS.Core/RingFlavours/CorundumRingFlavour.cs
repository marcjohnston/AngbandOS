namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class CorundumRingFlavour : RingFlavour
{
    private CorundumRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override string Name => "Corundum";
}
