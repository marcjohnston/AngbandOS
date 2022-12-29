namespace AngbandOS.Core;

[Serializable]
internal class OrangeSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeSplat";
}
