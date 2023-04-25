namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BrassRodFlavour : RodFlavour
{
    private BrassRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Brass";
}
