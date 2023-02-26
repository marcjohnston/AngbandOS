namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class TinPlatedWandFlavour : WandFlavour
{
    private TinPlatedWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Tin-Plated";
}
