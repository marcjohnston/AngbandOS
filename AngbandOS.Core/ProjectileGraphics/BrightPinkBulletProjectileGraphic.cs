namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightPinkBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkBullet";
}
