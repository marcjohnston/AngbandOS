using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SlimyMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "Slimy";
}
