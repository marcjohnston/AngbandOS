namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class AluminiumPlatedWandFlavour : WandFlavour
{
    private AluminiumPlatedWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Aluminium-Plated";
}
