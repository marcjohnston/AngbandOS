namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class YellowBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowBolt";
}
