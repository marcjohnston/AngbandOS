namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightRedBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedBullet";
}
