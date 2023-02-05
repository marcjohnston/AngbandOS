namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightGreySplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreySplat";
}
