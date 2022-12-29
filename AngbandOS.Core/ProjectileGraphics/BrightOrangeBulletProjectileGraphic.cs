namespace AngbandOS.Core;

[Serializable]
internal class BrightOrangeBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeBullet";
}
