namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class DiamondSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondSplat";
}
