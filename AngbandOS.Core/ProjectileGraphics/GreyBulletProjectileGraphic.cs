namespace AngbandOS.Core;

[Serializable]
internal class GreyBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyBullet";
}
