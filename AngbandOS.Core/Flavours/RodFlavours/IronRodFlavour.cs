namespace AngbandOS.Core.Flavours;

[Serializable]
internal class IronRodFlavour : RodFlavour
{
    private IronRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Iron";
}
