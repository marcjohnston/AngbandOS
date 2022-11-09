using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ChartreuseBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseBullet";
}
