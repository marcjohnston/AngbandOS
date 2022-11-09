using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightGreyBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyBullet";
}
