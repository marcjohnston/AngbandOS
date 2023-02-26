namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GreyBulletProjectileGraphic : ProjectileGraphic
{
    private GreyBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyBullet";
}
