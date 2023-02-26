namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightTurquoiseSplatProjectileGraphic : ProjectileGraphic
{
    private BrightTurquoiseSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseSplat";
}
