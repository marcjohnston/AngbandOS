namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class AluminiumWandFlavour : WandFlavour
{
    private AluminiumWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Aluminium";
}
