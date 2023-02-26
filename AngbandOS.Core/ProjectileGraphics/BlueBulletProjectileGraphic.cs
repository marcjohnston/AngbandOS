namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BlueBulletProjectileGraphic : ProjectileGraphic
{
    private BlueBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueBullet";
}
