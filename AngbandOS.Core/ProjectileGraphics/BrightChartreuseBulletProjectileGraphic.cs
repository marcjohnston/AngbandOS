namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightChartreuseBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseBullet";
}
