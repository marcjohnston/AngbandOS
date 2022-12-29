namespace AngbandOS.Core;

[Serializable]
internal class BrightPinkSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkSplat";
}
