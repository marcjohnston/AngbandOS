namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GoldBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldBullet";
}
