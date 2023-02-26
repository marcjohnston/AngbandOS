namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class WhiteBulletProjectileGraphic : ProjectileGraphic
{
    private WhiteBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override string Name => "WhiteBullet";
}
