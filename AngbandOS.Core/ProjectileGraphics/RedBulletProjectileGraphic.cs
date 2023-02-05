namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class RedBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedBullet";
}
