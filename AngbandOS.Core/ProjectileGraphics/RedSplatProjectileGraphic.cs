using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedSplat";
}
