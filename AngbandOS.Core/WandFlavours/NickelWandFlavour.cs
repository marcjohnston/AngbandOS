namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class NickelWandFlavour : WandFlavour
{
    private NickelWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Nickel";
}
