namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightWhiteSplatProjectileGraphic : ProjectileGraphic
{
    private BrightWhiteSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteSplat";
}
