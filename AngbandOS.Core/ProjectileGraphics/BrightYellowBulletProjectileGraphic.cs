using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightYellowBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowBullet";
}
