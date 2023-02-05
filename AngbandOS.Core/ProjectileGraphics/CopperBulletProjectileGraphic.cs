namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class CopperBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperBullet";
}
