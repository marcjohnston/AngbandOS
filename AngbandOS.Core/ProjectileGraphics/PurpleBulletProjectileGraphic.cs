namespace AngbandOS.Core;

[Serializable]
internal class PurpleBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleBullet";
}
