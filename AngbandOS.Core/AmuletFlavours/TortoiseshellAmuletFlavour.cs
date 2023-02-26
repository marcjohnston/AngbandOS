namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class TortoiseshellAmuletFlavour : AmuletFlavour
{
    private TortoiseshellAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Tortoiseshell";
}
