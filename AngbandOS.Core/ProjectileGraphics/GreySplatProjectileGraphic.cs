namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GreySplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreySplat";
}
