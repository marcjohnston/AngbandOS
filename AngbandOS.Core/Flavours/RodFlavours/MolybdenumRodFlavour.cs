namespace AngbandOS.Core.Flavours;

[Serializable]
internal class MolybdenumRodFlavour : RodFlavour
{
    private MolybdenumRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Molybdenum";
}
