namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class TurquoiseBoltProjectileGraphic : ProjectileGraphic
{
    private TurquoiseBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseBolt";
}
