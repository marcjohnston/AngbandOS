namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class TurquoiseBulletProjectileGraphic : ProjectileGraphic
{
    private TurquoiseBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseBullet";
}
