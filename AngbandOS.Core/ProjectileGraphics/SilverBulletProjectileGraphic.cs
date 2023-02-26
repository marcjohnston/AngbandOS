namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class SilverBulletProjectileGraphic : ProjectileGraphic
{
    private SilverBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverBullet";
}
