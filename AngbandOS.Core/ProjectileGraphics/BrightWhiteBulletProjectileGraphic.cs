namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightWhiteBulletProjectileGraphic : ProjectileGraphic
{
    private BrightWhiteBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteBullet";
}
