using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightPurpleSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleSplat";
}
