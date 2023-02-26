namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightOrangeBulletProjectileGraphic : ProjectileGraphic
{
    private BrightOrangeBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeBullet";
}
