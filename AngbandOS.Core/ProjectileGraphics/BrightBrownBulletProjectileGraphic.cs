namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightBrownBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownBullet";
}
