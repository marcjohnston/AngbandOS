namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightTurquoiseBoltProjectileGraphic : ProjectileGraphic
{
    private BrightTurquoiseBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseBolt";
}
