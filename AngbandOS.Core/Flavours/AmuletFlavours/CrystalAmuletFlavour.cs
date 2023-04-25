namespace AngbandOS.Core.Flavours;

[Serializable]
internal class CrystalAmuletFlavour : AmuletFlavour
{
    private CrystalAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Crystal";
}
