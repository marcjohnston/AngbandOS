namespace AngbandOS.Core.Flavours;

[Serializable]
internal class MolybdenumWandFlavour : WandFlavour
{
    private MolybdenumWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Molybdenum";
}
