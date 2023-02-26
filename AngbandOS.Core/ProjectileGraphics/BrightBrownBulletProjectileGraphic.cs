namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightBrownBulletProjectileGraphic : ProjectileGraphic
{
    private BrightBrownBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownBullet";
}
