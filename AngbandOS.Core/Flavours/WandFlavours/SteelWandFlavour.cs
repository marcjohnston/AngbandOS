namespace AngbandOS.Core.Flavours;

[Serializable]
internal class SteelWandFlavour : WandFlavour
{
    private SteelWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Steel";
}
