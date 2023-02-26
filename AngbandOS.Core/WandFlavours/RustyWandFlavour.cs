namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class RustyWandFlavour : WandFlavour
{
    private RustyWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Rusty";
}
