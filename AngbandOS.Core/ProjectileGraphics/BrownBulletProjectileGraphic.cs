namespace AngbandOS.Core;

[Serializable]
internal class BrownBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownBullet";
}
