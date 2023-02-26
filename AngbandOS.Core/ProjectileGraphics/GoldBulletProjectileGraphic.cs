namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GoldBulletProjectileGraphic : ProjectileGraphic
{
    private GoldBulletProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldBullet";
}
