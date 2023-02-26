namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class CopperBulletProjectileGraphic : ProjectileGraphic
{
    private CopperBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperBullet";
}
