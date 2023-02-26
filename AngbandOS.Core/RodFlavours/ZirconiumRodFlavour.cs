namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class ZirconiumRodFlavour : RodFlavour
{
    private ZirconiumRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Zirconium";
}
