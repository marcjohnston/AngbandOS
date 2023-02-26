namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrownBulletProjectileGraphic : ProjectileGraphic
{
    private BrownBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownBullet";
}
