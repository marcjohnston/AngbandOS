namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ShortWandFlavour : WandFlavour
{
    private ShortWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Short";
}
