using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightChartreuseSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseSplat";
}
