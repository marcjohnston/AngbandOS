using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PinkSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkSplat";
}
