namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GoldBoltProjectileGraphic : ProjectileGraphic
{
    private GoldBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldBolt";
}
