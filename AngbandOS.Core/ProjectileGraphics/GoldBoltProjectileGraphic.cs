namespace AngbandOS.Core;

[Serializable]
internal class GoldBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldBolt";
}
