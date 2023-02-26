namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class RedBulletProjectileGraphic : ProjectileGraphic
{
    private RedBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedBullet";
}
