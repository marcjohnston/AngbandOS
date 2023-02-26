namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightGreenBoltProjectileGraphic : ProjectileGraphic
{
    private BrightGreenBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenBolt";
}
