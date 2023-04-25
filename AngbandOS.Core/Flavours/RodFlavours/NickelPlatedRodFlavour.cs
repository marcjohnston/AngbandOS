namespace AngbandOS.Core.Flavours;

[Serializable]
internal class NickelPlatedRodFlavour : RodFlavour
{
    private NickelPlatedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Nickel-Plated";
}
