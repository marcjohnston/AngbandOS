namespace AngbandOS.Core.Flavours;

[Serializable]
internal class TinWandFlavour : WandFlavour
{
    private TinWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Tin";
}
