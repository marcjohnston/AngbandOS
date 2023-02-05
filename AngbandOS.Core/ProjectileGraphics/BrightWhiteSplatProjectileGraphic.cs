namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightWhiteSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteSplat";
}
