namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightPurpleBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleBullet";
}
