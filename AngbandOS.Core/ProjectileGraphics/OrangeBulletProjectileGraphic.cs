namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class OrangeBulletProjectileGraphic : ProjectileGraphic
{
    private OrangeBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeBullet";
}
