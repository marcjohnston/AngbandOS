namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class SteelPlatedWandFlavour : WandFlavour
{
    private SteelPlatedWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Steel-Plated";
}
