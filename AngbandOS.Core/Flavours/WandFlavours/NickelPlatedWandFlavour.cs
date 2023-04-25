namespace AngbandOS.Core.Flavours;

[Serializable]
internal class NickelPlatedWandFlavour : WandFlavour
{
    private NickelPlatedWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Nickel-Plated";
}
