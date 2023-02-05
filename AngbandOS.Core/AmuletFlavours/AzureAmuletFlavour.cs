namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class AzureAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Azure";
}
