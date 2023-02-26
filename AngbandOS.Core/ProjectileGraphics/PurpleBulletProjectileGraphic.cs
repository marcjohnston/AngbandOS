namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class PurpleBulletProjectileGraphic : ProjectileGraphic
{
    private PurpleBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleBullet";
}
