namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class TurquoiseSplatProjectileGraphic : ProjectileGraphic
{
    private TurquoiseSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseSplat";
}
