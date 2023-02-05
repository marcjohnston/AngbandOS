namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class PinkBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkBullet";
}
