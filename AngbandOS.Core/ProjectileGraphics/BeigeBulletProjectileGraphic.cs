namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BeigeBulletProjectileGraphic : ProjectileGraphic
{
    private BeigeBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeBullet";
}
