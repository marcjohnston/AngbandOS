namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightPurpleBulletProjectileGraphic : ProjectileGraphic
{
    private BrightPurpleBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleBullet";
}
