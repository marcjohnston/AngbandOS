namespace AngbandOS.Core;

[Serializable]
internal class BrightBeigeBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeBullet";
}
