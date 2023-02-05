namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightRedSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedSplat";
}
