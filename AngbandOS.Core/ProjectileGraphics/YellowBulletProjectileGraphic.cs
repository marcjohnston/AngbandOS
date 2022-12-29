namespace AngbandOS.Core;

[Serializable]
internal class YellowBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowBullet";
}
