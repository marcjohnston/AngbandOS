namespace AngbandOS.Core;

[Serializable]
internal class GoldSplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldSplat";
}
