namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class AluminiumPlatedRodFlavour : RodFlavour
{
    private AluminiumPlatedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Aluminium-Plated";
}
