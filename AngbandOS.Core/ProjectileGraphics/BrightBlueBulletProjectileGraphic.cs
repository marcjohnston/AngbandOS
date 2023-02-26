namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightBlueBulletProjectileGraphic : ProjectileGraphic
{
    private BrightBlueBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueBullet";
}
