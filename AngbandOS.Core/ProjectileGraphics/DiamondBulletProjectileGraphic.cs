namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class DiamondBulletProjectileGraphic : ProjectileGraphic
{
    private DiamondBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondBullet";
}
