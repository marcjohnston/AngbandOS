namespace AngbandOS.Core.Flavours;

[Serializable]
internal class LongRodFlavour : RodFlavour
{
    private LongRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Long";
}
