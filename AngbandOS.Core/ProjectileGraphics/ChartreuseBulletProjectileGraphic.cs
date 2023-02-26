namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class ChartreuseBulletProjectileGraphic : ProjectileGraphic
{
    private ChartreuseBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseBullet";
}
