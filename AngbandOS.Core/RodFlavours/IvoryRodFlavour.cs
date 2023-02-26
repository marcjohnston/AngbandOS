namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class IvoryRodFlavour : RodFlavour
{
    private IvoryRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Ivory";
}
