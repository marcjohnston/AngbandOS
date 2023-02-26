namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightOrangeBoltProjectileGraphic : ProjectileGraphic
{
    private BrightOrangeBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeBolt";
}
