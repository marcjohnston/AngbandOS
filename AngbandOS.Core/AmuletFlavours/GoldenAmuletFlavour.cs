namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class GoldenAmuletFlavour : AmuletFlavour
{
    private GoldenAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Golden";
}
