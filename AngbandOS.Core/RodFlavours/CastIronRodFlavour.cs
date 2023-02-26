namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class CastIronRodFlavour : RodFlavour
{
    private CastIronRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Cast Iron";
}
