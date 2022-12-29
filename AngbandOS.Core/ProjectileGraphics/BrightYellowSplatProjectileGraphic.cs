namespace AngbandOS.Core;

[Serializable]
internal class BrightYellowSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowSplat";
}
