namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightPinkBulletProjectileGraphic : ProjectileGraphic
{
    private BrightPinkBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkBullet";
}
