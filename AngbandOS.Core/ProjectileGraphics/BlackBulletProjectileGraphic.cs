namespace AngbandOS.Core;

[Serializable]
internal class BlackBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackBullet";
}
