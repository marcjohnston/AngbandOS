namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class PlatinumWandFlavour : WandFlavour
{
    private PlatinumWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Platinum";
}
