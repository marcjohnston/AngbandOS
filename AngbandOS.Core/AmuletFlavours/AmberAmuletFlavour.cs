namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class AmberAmuletFlavour : AmuletFlavour
{
    private AmberAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Amber";
}
