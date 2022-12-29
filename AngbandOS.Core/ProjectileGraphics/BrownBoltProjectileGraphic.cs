namespace AngbandOS.Core;

[Serializable]
internal class BrownBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownBolt";
}
