namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class PinkBulletProjectileGraphic : ProjectileGraphic
{
    private PinkBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkBullet";
}
