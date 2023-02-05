namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BlackBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackBullet";
}
