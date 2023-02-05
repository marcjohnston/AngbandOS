namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GreenSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenSplat";
}
