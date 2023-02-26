namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class SlimyMushroomFlavour : MushroomFlavour
{
    private SlimyMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "Slimy";
}
