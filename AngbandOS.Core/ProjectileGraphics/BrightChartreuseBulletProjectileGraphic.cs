namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightChartreuseBulletProjectileGraphic : ProjectileGraphic
{
    private BrightChartreuseBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseBullet";
}
