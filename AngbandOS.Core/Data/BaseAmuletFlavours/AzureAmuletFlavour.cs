using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class AzureAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Azure";
}
