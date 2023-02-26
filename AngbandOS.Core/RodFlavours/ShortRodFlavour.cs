namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class ShortRodFlavour : RodFlavour
{
    private ShortRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Green;
    public override string Name => "Short";
}
