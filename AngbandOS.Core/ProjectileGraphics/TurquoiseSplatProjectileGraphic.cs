namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseSplat";
}
