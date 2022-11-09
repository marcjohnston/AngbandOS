using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBrownSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownSplat";
}
