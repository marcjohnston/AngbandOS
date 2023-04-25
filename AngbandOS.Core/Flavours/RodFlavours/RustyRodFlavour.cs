namespace AngbandOS.Core.Flavours;

[Serializable]
internal class RustyRodFlavour : RodFlavour
{
    private RustyRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Rusty";
}
