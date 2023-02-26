namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightGreenBulletProjectileGraphic : ProjectileGraphic
{
    private BrightGreenBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenBullet";
}
