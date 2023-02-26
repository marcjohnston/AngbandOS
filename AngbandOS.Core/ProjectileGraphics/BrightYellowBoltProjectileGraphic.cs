namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightYellowBoltProjectileGraphic : ProjectileGraphic
{
    private BrightYellowBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowBolt";
}
