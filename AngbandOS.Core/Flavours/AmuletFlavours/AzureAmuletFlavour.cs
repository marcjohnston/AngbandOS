namespace AngbandOS.Core.Flavours;

[Serializable]
internal class AzureAmuletFlavour : AmuletFlavour
{
    private AzureAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Azure";
}
