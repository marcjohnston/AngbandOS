namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class ChartreuseBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseBullet";
}
