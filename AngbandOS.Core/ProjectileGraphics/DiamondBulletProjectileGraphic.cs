namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class DiamondBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondBullet";
}
