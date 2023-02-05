namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class SilverBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverBolt";
}
