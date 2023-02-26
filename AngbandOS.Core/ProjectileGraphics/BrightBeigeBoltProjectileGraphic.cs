namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightBeigeBoltProjectileGraphic : ProjectileGraphic
{
    private BrightBeigeBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeBolt";
}
