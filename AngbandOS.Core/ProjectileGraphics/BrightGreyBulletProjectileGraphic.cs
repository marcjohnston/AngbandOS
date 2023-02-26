namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightGreyBulletProjectileGraphic : ProjectileGraphic
{
    private BrightGreyBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyBullet";
}
