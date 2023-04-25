namespace AngbandOS.Core.Flavours;

[Serializable]
internal class TinRodFlavour : RodFlavour
{
    private TinRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Tin";
}
